namespace CMS.Server.DL
{
    using CMS.Server.Model;
    using CMS.Server.Model.DBResponses;
    using System.Collections.Generic;

    public interface IContractRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public CreateResponse CreateContract(Contract contract);
        public CreateResponse CreateInfo(Info info);
        public CreateResponse CreateAddress(Address address);
        public CreateResponse CreateContractor(Contractor contractor);
        public CreateResponse CreateLiability(Liability liability);
        public CreateResponse CreateClaim(Claim claim);
        public CreateResponse CreateDepartment(Department department);
        public CreateResponse CreateDepartments(List<Department> departments);
        public CreateResponse CreateFine(Fine fine);
        public CreateResponse CreateCategory(Category category);
        public CreateResponse CreateDuty(Duty duty);
        public CreateResponse CreateNotification(Notification notification);
        public CreateResponse CreateComment(Comment comment);
        public CreateResponse CreateSign(Sign sign);
        public CreateResponse CreateFile(DataFile file);


        /// <summary>
        /// Read
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public ReadResponse<bool> IsContractActive(string userToken);
        public ReadResponse<List<ContractStatus>> ReadContractStatusType();
        public ReadResponse<List<ContractType>> ReadContractType();
        public ReadResponse<List<Info>> ReadInfo();
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
        public ReadResponse<Info> ReadInfoByUserToken(string userToken);
        public ReadResponse<List<CategoryType>> ReadCategoryType();
        public ReadResponse<List<Category>> ReadCategory(int id);
        public ReadResponse<List<DutyType>> ReadDutyType();
        public ReadResponse<List<Duty>> ReadDuty(int id);
        public ReadResponse<List<NotificationType>> ReadNotificationType();
        public ReadResponse<List<Notification>> ReadNotification(int id);
        public ReadResponse<List<Comment>> ReadComment(int id);
        public ReadResponse<List<Sign>> ReadSign(int id);
        public ReadResponse<List<File>> ReadFile(int id);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public UpdateResponse UpdateContractStatus(string userToken);
        public UpdateResponse UpdateInfo(Info info);
        public UpdateResponse UpdateAddress(Address address);
        public UpdateResponse UpdateContractor(Contractor contractor);
        public UpdateResponse UpdateLiability(Liability liability);
        public UpdateResponse UpdateClaim(Claim claim);
        public UpdateResponse UpdateFine(Fine fine);
        public UpdateResponse UpdateCategory(Category category);
        public UpdateResponse UpdateDuty(Duty duty);
        public UpdateResponse UpdateComment(Comment comment);
        public UpdateResponse UpdateNotification(Notification notification);
        public UpdateResponse UpdateSign(Sign sign);
        public UpdateResponse UpdateFile(File file);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public DeleteResponse DeleteDepartment(int id);
        public DeleteResponse DeleteLiabilityById(int id);
        public DeleteResponse DeleteClaimById(int id);
        public DeleteResponse DeleteDepartmentById(int id);
        public DeleteResponse DeleteDepartments(List<int> idCollection);
        public DeleteResponse DeleteFineById(int id);
        public DeleteResponse DeleteCategoryById(int id);
        public DeleteResponse DeleteDutyById(int id);
        public DeleteResponse DeleteNotificationById(int id);
        public DeleteResponse DeleteCommentById(int id);
        public DeleteResponse DeleteSignById(int id);
        public DeleteResponse DeleteFileById(int id);
    }
}
