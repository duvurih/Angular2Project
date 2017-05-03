using Hk.CommonServices.Core.Interfaces.External;
using Hk.CommonServices.Core.Models;
using Hk.CommonServices.Repository.Interface;
using Hk.Services.Connector.Interface;
using Hk.Utilities.GenericComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hk.CommonServices.Services.External
{
    public class SmsService : GenericService<SMSInformation>, ISmsService
    {
        ISmsConnectorService _iSmsConnectorService;
        ISmsRepository _iSmsRepository;

        public SmsService(ISmsConnectorService iSmsConnectorService, ISmsRepository iSmsRepository)
            : base(iSmsRepository)
        {
            _iSmsConnectorService = iSmsConnectorService;
            _iSmsRepository = iSmsRepository;
        }

        public async Task<bool> ReceivedSMSDeliveryStatus(SMSInformation smsDeliveryStatus)
        {
            bool status = await _iSmsConnectorService.ReceivedSMSDeliveryNotification(smsDeliveryStatus);
            if (status == true)
            {
                _iSmsRepository.Update(smsDeliveryStatus);
            }
            return status;
        }

        public async Task<bool> ReceivedSMSNotification(SMSInformation smsNotification)
        {
            bool status = await _iSmsConnectorService.ReceivedSMSNotification(smsNotification);
            if (status == true)
            {
                _iSmsRepository.Update(smsNotification);
            }
            return status;
        }

        public async Task<bool> SendSMS(SMSInformation smsContent)
        {
            bool status = await _iSmsConnectorService.SendSMS(smsContent);
            if (status == true)
            {
                _iSmsRepository.Insert(smsContent);
            }
            return status;
        }

        public async Task<bool> SendSMSMultiple(IEnumerable<SMSInformation> smsMultiple)
        {
            bool status = await _iSmsConnectorService.SendSMSMultiple(smsMultiple);
            if (status == true)
            {
                _iSmsRepository.InsertMultiple(smsMultiple);
            }
            return status;
        }
    }
}
