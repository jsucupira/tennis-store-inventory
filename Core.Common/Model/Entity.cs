﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Common.Model
{
    [DataContract]
    public abstract class Entity<TId> : IDataErrorInfo, IEntity
    {
        protected Entity()
        {
            _validator = GetValidator();
        }
        
        public TId Id { get; protected set; }

        #region Validation

        [IgnoreDataMember]
        public virtual bool IsValid
        {
            get
            {
                if (_validationErrors != null && _validationErrors.Any())
                    return false;
                return true;
            }
        }

        [IgnoreDataMember]
        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get { return _validationErrors; }
        }

        [IgnoreDataMember]
        public string ValidationErrorsMessage
        {
            get
            {
                StringBuilder errors = new StringBuilder();

                if (_validationErrors != null && _validationErrors.Any())
                {
                    foreach (ValidationFailure validationError in _validationErrors)
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
                _validationErrors = results.Errors;
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

                if (_validationErrors != null && _validationErrors.Any())
                {
                    foreach (ValidationFailure validationError in _validationErrors)
                    {
                        if (validationError.PropertyName == columnName)
                            errors.AppendLine(validationError.ErrorMessage);
                    }
                }

                return errors.ToString();
            }
        }

        #endregion

        private IEnumerable<ValidationFailure> _validationErrors;
        private readonly IValidator _validator;
        
        public bool IsActive { get; private set; }
        public bool IsLocked { get; private set; }
        public string LockedBy { get; private set; }
        public DateTime CreatedDate { get; protected set; }
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
        public void LockEntity(string lockedBy)
        {
            IsLocked = true;
            LockedBy = lockedBy;
        }

        public void ModifiedBy(string userName)
        {
            LastModifiedBy = userName;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void UnlockEntity()
        {
            IsLocked = false;
            LockedBy = string.Empty;
        }
    }
}