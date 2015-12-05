using System;
using System.Collections.Generic;
using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.StoreAggregate
{
    [Serializable]
    public sealed class Store : Entity<Guid>
    {
        public Store(string name, string description)
            : this()
        {
            Name = name;
            Description = description;
        }

        private Store()
        {
            Id = Guid.NewGuid();
            OpenDate = DateTime.UtcNow;
            CreatedDate = DateTime.UtcNow;
        }

        public DateTime? ClosedDate { get; set; }
        public string Description { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerName { get; set; }
        public string Name { get; private set; }
        public DateTime OpenDate { get; set; }
        public IReadOnlyList<StoreAddress> StoreAddresses { get; private set; }
        public IReadOnlyList<StoreContact> StoreContacts { get; private set; }
        public string UserDefined1 { get; set; }
        public string UserDefined10 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
        public string UserDefined5 { get; set; }
        public string UserDefined6 { get; set; }
        public string UserDefined7 { get; set; }
        public string UserDefined8 { get; set; }
        public string UserDefined9 { get; set; }
        public string UserDefinedDescription1 { get; set; }
        public string UserDefinedDescription10 { get; set; }
        public string UserDefinedDescription2 { get; set; }
        public string UserDefinedDescription3 { get; set; }
        public string UserDefinedDescription4 { get; set; }
        public string UserDefinedDescription5 { get; set; }
        public string UserDefinedDescription6 { get; set; }
        public string UserDefinedDescription7 { get; set; }
        public string UserDefinedDescription8 { get; set; }
        public string UserDefinedDescription9 { get; set; }
        public string WebSiteUrl { get; set; }

        internal void SetCollections(IReadOnlyList<StoreAddress> storeAddresses, IReadOnlyList<StoreContact> storeContact)
        {
            StoreAddresses = storeAddresses;
            StoreContacts = storeContact;
        }

        protected override IValidator GetValidator()
        {
            return new StoreValidator();
        }
    }
}