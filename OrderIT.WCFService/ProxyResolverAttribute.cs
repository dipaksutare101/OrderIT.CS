using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using System.Data.Objects;
using System.ServiceModel.Channels;

namespace OrderIT.WCFService {
	public class ProxyResolverAttribute : Attribute, IOperationBehavior {
		public ProxyResolverAttribute() {
		}

		public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters) {
		}

		public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy) {
			SetResolver(description);
		}

		public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch) {
			SetResolver(description);
		}

		public void Validate(OperationDescription operationDescription) {
		}

		private void SetResolver(OperationDescription description){
			var dataContractSerializerOperationBehavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
			dataContractSerializerOperationBehavior.DataContractResolver = new ProxyDataContractResolver();
		}
	}
}