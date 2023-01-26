using Online_Banking_System.data.dto;
using Online_Banking_System.data.models;

namespace Online_Banking_System.data.beanmapper
{
    public class BeanMapper
    {
        public ClientDto toDto(Client entity)
        {
            ClientDto dto = new ClientDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Status = entity.Status;
            dto.Accounts = entity.Accounts;

            return dto;
        }

        public Client toEntity(ClientDto dto)
        {
            Client entity = new Client();
            entity.Id= dto.Id;
            entity.Name = dto.Name;
            entity.Status = dto.Status;
            entity.Accounts = dto.Accounts;

            return entity;
        }
    }
}
