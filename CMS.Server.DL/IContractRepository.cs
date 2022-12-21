namespace CMS.Server.DL
{
    using CMS.Server.Model;
    using CMS.Server.Model.DBResponses;
    using System.Collections.Generic;

    public interface IContractRepository
    {
        public CreateResponse CreateContract(Contract contract);
        public ReadResponse<bool> IsContractActive(string userToken);

        public ReadResponse<bool> IsContractActive(int id);

        public UpdateResponse UpdateContractStatus(string userToken);

        public UpdateResponse UpdateContractStatus(int id);

        public CreateResponse CreateInfo(Info info);

        public CreateResponse CreateAddress(Address address);
        public CreateResponse CreateContractor(Contractor contractor);
        public CreateResponse CreateLiability(Liability liability);
        public CreateResponse CreateClaim(Claim claim);
        public CreateResponse CreateDepartment(Department department);
        public CreateResponse CreateDepartments(List<Department> departments);
        public DeleteResponse DeleteDepartment(int id);
        public DeleteResponse DeleteDepartments(List<int> idCollection);
        public CreateResponse CreateFine(Fine fine);
        public ReadResponse<List<ContractStatus>> ReadContractStatusType();
        public ReadResponse<List<ContractType>> ReadContractType();
        public ReadResponse<List<Info>> ReadInfo();
        public ReadResponse<List<int>> ReadAllActiveId();
        public ReadResponse<Info> ReadLastInfo();
        public ReadResponse<List<Address>> ReadAddress();
        public ReadResponse<List<Contractor>> ReadContractor(int id);
        public ReadResponse<List<LiabilityType>> ReadLiabilityType();
        public ReadResponse<List<Liability>> ReadLiability(int id);
        public ReadResponse<List<ClaimType>> ReadClaimType();
        public ReadResponse<List<Claim>> ReadClaim(int id);
        public ReadResponse<List<DepartmentType>> ReadDepartmentType();
        public ReadResponse<List<Department>> ReadDepartment(int id);
        public ReadResponse<List<FineType>> ReadFineType();
        public ReadResponse<List<Fine>> ReadFine(int id);
        public ReadResponse<int> GetLastId(string tableName);
        public ReadResponse<bool> HasInfoAlreadyCreated(int contractId);
        public ReadResponse<int> ReadContractIdByUsertoken(string userToken);
        public ReadResponse<Info> ReadInfoById(int id);
        public UpdateResponse UpdateInfo(Info info);
        public UpdateResponse UpdateAddress(Address address);
        public UpdateResponse UpdateContractor(Contractor contractor);
        public UpdateResponse UpdateLiability(Liability liability);
        public UpdateResponse UpdateClaim(Claim claim);
        public UpdateResponse UpdateFine(Fine fine);
        public ReadResponse<List<CategoryType>> ReadCategoryType();
        public ReadResponse<List<Category>> ReadCategory(int id);
        public ReadResponse<List<DutyType>> ReadDutyType();
        public ReadResponse<List<Duty>> ReadDuty(int id);
        public CreateResponse CreateCategory(Category category);
        public CreateResponse CreateDuty(Duty duty);
        public UpdateResponse UpdateCategory(Category category);
        public UpdateResponse UpdateDuty(Duty duty);
        public CreateResponse CreateNotification(Notification notification);
        public UpdateResponse UpdateNotification(Notification notification);
        public ReadResponse<List<NotificationType>> ReadNotificationType();
        public ReadResponse<List<Notification>> ReadNotification(int id);
        public CreateResponse CreateComment(Comment comment);
        public UpdateResponse UpdateComment(Comment comment);
        public ReadResponse<List<Comment>> ReadComment(int id);
        public CreateResponse CreateSign(Sign sign);
        public UpdateResponse UpdateSign(Sign sign);
        public ReadResponse<List<Sign>> ReadSign(int id);

        public ReadResponse<bool> Exists(int id, string table);
    }
}
