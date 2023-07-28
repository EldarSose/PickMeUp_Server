using PickMeUp.Core.Entities;
using PickMeUp.DTO.AddModel;
using PickMeUp.DTO.EditModel;
using PickMeUp.DTO.ViewModel;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Repository.Repositories;
using PickMeUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Service.Services
{
	public class TaxiContactService : BaseService<TaxiContact, int>, ITaxiContactService
	{
		private readonly ITaxiContactRepository taxiContactRepository;
		private readonly ITaxiRepository taxiRepository;
		private readonly IContactRepository contactRepository;

		public TaxiContactService(IGenericRepository<TaxiContact, int> genericRepository,
			ITaxiContactRepository taxiContactRepository,
			ITaxiRepository taxiRepository,
			IContactRepository contactRepository) : base(genericRepository)
		{
			this.taxiContactRepository = taxiContactRepository;
			this.taxiRepository = taxiRepository;
			this.contactRepository = contactRepository;
		}

		public TaxiContactVM? Add(TaxiContactAdd taxiContact)
		{
			if (taxiContact.taxiId == null || taxiContact.contactId == null)
				return null;


			genericRepository.Add(new TaxiContact
			{
				taxiId = taxiContact.taxiId,
				contactId = taxiContact.contactId,
				isDeleted = false,
			});

			Taxi taxi = new Taxi();
			Contact contact = new Contact();

			if (taxiContact.taxiId.HasValue)
				taxi = taxiRepository.GetById(taxiContact.taxiId.Value);

			if (taxiContact.contactId.HasValue)
				contact = contactRepository.GetById(taxiContact.contactId.Value);

			return new TaxiContactVM
			{
				taxiName = taxi.taxiName,
				contact = contact.contactName
			};
		}

		public bool Delete(int id)
		{
			return taxiContactRepository.Delete(id);
		}

		public TaxiContactVM? Update(TaxiContactEdit taxiContact)
		{
			if (taxiContact.taxiId == null || taxiContact.contactId == null)
				return null;

			TaxiContact tx = taxiContactRepository.GetAll().FirstOrDefault(x => x.taxiId == taxiContact.taxiId);

			if(tx == null) return null;

			tx.contactId = taxiContact.contactId;

			genericRepository.Update(tx);

			Taxi taxi = new Taxi();
			Contact contact = new Contact();

			if (taxiContact.taxiId.HasValue)
				taxi = taxiRepository.GetById(taxiContact.taxiId.Value);

			if (taxiContact.contactId.HasValue)
				contact = contactRepository.GetById(taxiContact.contactId.Value);

			return new TaxiContactVM
			{
				taxiName = taxi.taxiName,
				contact = contact.contactName
			};
		}
	}
}
