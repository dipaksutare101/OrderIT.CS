using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Diagnostics;
using System.ServiceModel.Configuration;

namespace OrderIT.WCFService {
	public class ErrorBehavior : IErrorHandler, IServiceBehavior {
		public void AddBindingParameters(
				ServiceDescription serviceDescription,
				ServiceHostBase serviceHostBase,
				Collection<ServiceEndpoint> endpoints,
				BindingParameterCollection bindingParameters) {
		}

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
			IErrorHandler errorHandler = new ErrorBehavior();

			foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers) {
				ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;

				if (channelDispatcher != null) {
					channelDispatcher.ErrorHandlers.Add(errorHandler);
				}
			}
		}

		public bool HandleError(Exception error) {
			Trace.TraceError(error.ToString());
			return true;
		}

		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
		}

		public void ProvideFault(Exception error, MessageVersion version, ref Message fault) {
			// Shield the unknown exception
			FaultException faultException = new FaultException(
					"Server error encountered. All details have been logged.");
			MessageFault messageFault = faultException.CreateMessageFault();

			fault = Message.CreateMessage(version, messageFault, faultException.Action);
		}
	}

	public class ErrorHandlerElement : BehaviorExtensionElement {
		protected override object CreateBehavior() {
			return new ErrorBehavior();
		}

		public override Type BehaviorType {
			get {
				return typeof(ErrorBehavior);
			}
		}
	}
}