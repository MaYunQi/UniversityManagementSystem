﻿namespace UniversityManagementSystem.Domain.Entities.OtherEntity
{
    public class Nation : BaseEntity
    {
        public short NationId { get; private set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; }
    }
}
