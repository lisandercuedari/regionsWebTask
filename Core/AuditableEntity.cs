﻿using System;

 namespace Domain
{
    //Each entity will have it as a base class. 
    //Multiple inheritance will not be a problem for entities of this task, thus entities will just inherit from this class
    //rather than designing it as an interface to implement by the entities for the audit behaviour
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        
        public DateTime? LastModified { get; set; }
    }
}
