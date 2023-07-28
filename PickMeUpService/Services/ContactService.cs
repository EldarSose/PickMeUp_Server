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
	public class ContactService : BaseService<Contact, int>, IContactService
	{
		private readonly IContactRepository contactRepository;

		public ContactService(IGenericRepository<Contact, int> genericRepository,
			IContactRepository contactRepository) : base(genericRepository)
		{
			this.contactRepository = contactRepository;
		}

		public ContactVM? Add(ContactAdd contact)
		{
			if (string.IsNullOrWhiteSpace(contact.contactInfo) || string.IsNullOrWhiteSpace(contact.contactName))
				return null;
			genericRepository.Add(new Contact
			{
				contactName = contact.contactName,
				contactInfo = contact.contactInfo,
				isDeleted = false
			});

			return new ContactVM
			{
				contactName = contact.contactName,
				contactInfo = contact.contactInfo,
			};
		}

		public bool Delete(int id)
		{
			return contactRepository.Delete(id);
		}

		public ContactVM? Update(ContactEdit contact)
		{
			if (string.IsNullOrWhiteSpace(contact.contactInfo) || string.IsNullOrWhiteSpace(contact.contactName))
				return null;
			Contact c = contactRepository.GetById(contact.contactId);

			if (c == null) return null;

			c.contactName = contact.contactName;
			c.contactInfo = contact.contactInfo;
			genericRepository.Update(c);

			return new ContactVM
			{
				contactName = contact.contactName,
				contactInfo = contact.contactInfo,
			};
		}
	}
}
