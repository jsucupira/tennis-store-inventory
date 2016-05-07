using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Core.Common.Model
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public abstract class Entity<TId> : IDataErrorInfo, IEntity
    {
        [NonSerialized]

        private readonly IValidator _validator;

        protected Entity()
        {
            _validator = GetValidator();
        }

        public DateTime CreatedDate { get; protected set; }

        public TId Id { get; set; }

        public bool IsActive { get; private set; }
        public string LastModifiedBy { get; private set; }
        public DateTime LastModifiedDate { get; private set; }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActivate()
        {
            IsActive = false;
        }

        public void ModifiedBy(string userName)
        {
            LastModifiedBy = userName;
            LastModifiedDate = DateTime.UtcNow;
        }

        #region Validation

        [JsonIgnore]
        public virtual bool IsValid
        {
            get
            {
                if (ValidationErrors != null && ValidationErrors.Any())
                    return false;
                return true;
            }
        }

        [JsonIgnore]
        public IEnumerable<ValidationFailure> ValidationErrors { get; private set; }

        [JsonIgnore]
        public string ValidationErrorsMessage
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                if (ValidationErrors != null && ValidationErrors.Any())
                {
                    foreach (ValidationFailure validationError in ValidationErrors)
                        errors.AppendLine(validationError.ErrorMessage);
                }

                return errors.ToString();
            }
        }

        protected abstract IValidator GetValidator();

        public void VerifyValidation()
        {
            if (_validator != null)
            {
                ValidationResult results = _validator.Validate(this);
                ValidationErrors = results.Errors;
            }
        }

        #endregion

        #region IDataErrorInfo members

        string IDataErrorInfo.Error
        {
            get { return string.Empty; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                if (ValidationErrors != null && ValidationErrors.Any())
                {
                    foreach (ValidationFailure validationError in ValidationErrors)
                    {
                        if (validationError.PropertyName == columnName)
                            errors.AppendLine(validationError.ErrorMessage);
                    }
                }

                return errors.ToString();
            }
        }

        #endregion
    }
}