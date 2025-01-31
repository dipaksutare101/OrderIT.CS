//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using OrderIT.Model.Notifications;


namespace OrderIT.Model
{
    [DataContract(IsReference = true)]
    public partial class Shirt : Product 
    {
        #region Primitive Properties
    	
        [DataMember]
        public virtual int SleeveType
        {
            get { return _sleeveType; }
            set { _sleeveType = value; NotifyPropertyChanged("SleeveType"); }
        }
        private int _sleeveType;
        protected int SleeveTypeEdit { get; set; }
    	
        [DataMember]
        public virtual string Color
        {
            get { return _color; }
            set { _color = value; NotifyPropertyChanged("Color"); }
        }
        private string _color;
        protected string ColorEdit { get; set; }
    	
        [DataMember]
        public virtual string Size
        {
            get { return _size; }
            set { _size = value; NotifyPropertyChanged("Size"); }
        }
        private string _size;
        protected string SizeEdit { get; set; }
    	
        [DataMember]
        public virtual string Gender
        {
            get { return _gender; }
            set { _gender = value; NotifyPropertyChanged("Gender"); }
        }
        private string _gender;
        protected string GenderEdit { get; set; }
    	
        [DataMember]
        public virtual string Material
        {
            get { return _material; }
            set { _material = value; NotifyPropertyChanged("Material"); }
        }
        private string _material;
        protected string MaterialEdit { get; set; }

        #endregion
        #region IEditableObject
        private bool isEditing = false;
    
    	protected override void BeginEditProtected(){
            if (!isEditing) 
            {
        		SleeveTypeEdit = SleeveType;
        		ColorEdit = Color;
        		SizeEdit = Size;
        		GenderEdit = Gender;
        		MaterialEdit = Material;
                isEditing = true;
            }
    	}
    
        protected virtual void CancelEditProtected(){
            SleeveType = SleeveTypeEdit;
            Color = ColorEdit;
            Size = SizeEdit;
            Gender = GenderEdit;
            Material = MaterialEdit;
            isEditing = false;
        }
    
    	protected virtual void EndEditProtected(){
    	    isEditing = false;
        }
            

        #endregion
        #region Equality Operators
        public override bool Equals (object obj)
        {
            if (!this.GetType().IsInstanceOfType(obj) && !obj.GetType().IsInstanceOfType(this))
                return false;
                    
            Shirt o = (Shirt)obj;
            return (1==1
              && this.ProductId == o.ProductId 
            );
        }
    
        public override int GetHashCode()
        {
            return (1
              ^ this.ProductId.GetHashCode()
            );
        }

        #endregion
    }
}
