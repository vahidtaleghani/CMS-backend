﻿namespace CMS.Server.BL
{
    using CMS.Server.DL;
    using CMS.Server.Model;
    using CMS.Server.Model.DBResponses;
    using CMS.Server.Model.ServerResponses;
    using CMS.Singleton;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CMSServerOperationsHandler
    {
        private readonly CMSDatabase _cmsDatabase;
        public CMSServerOperationsHandler()
        {
            this._cmsDatabase = new CMSDatabase();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public CreateResponse CreateContract(Contract contract)
        {
            UpdateResponse response = null;

            if (!(contract is null))
            {
                //var updateContractStatusResposne = this.UpdateContractStatus(contract.Usertoken);

                response = this.UpdateContractStatus(contract.Id);
            }

            var createResponse = this._cmsDatabase.ContractRepository.CreateContract(contract);

            if (createResponse.IsExecuted)
                return createResponse;

            return new CreateResponse(false, response.Message);
        }

        public UpdateResponse UpdateContractStatus(int id)
        {
            return this._cmsDatabase.ContractRepository.UpdateContractStatus(id);
        }
<<<<<<< HEAD

        public UpdateResponse UpdateContractStatus(string userToken)
        {
            return this._cmsDatabase.ContractRepository.UpdateContractStatus(userToken);
        }

        public CreateResponse CreateInfo(Info info)
=======
        public CreateResponse CreateInfo(Info info, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.HasInfoAlreadyCreated(info.ContractId).Data)
            {
                var updateResponse = this._cmsDatabase.ContractRepository.UpdateInfo(info);

                return new CreateResponse(updateResponse.IsExecuted, updateResponse.Message);
            }

            return this._cmsDatabase.ContractRepository.CreateInfo(info);
        }
<<<<<<< HEAD

        public ReadResponse<List<ContractType>> ReadAllContractType()
        {
            return this._cmsDatabase.ContractRepository.ReadContractType();
        }

        public ReadResponse<List<ContractStatus>> ReadAllContractStatus()
        {
            return this._cmsDatabase.ContractRepository.ReadContractStatusType();
        }

        public ReadResponse<Info> ReadInfoById(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadInfoById(id);
        }

        public CreateResponse CreateContractor(Contractor contractor)
=======
        public CreateResponse CreateContractor(Contractor contractor, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(contractor.ContractId))
            {
                if (contractor.Id != 0)
                {
                    var updateContractorResponse = this.UpdateContractor(contractor);

                    if (updateContractorResponse.IsExecuted)
                    {
                        contractor.Address.ContractorId = contractor.Id;
                        var updateAddressResponse = this.UpdateAddress(contractor.Address);

                        if (updateAddressResponse.IsExecuted)
                        {
                            return new CreateResponse(updateContractorResponse.IsExecuted, updateContractorResponse.Message);
                        }
                    }

                    return new CreateResponse(false, "Contractor cant be updated");
                }

                var contractorResponse = this._cmsDatabase.ContractRepository.CreateContractor(contractor);

                if (contractorResponse.IsExecuted)
                {
                    contractor.Address.ContractorId = this._cmsDatabase.ContractRepository.GetLastId("contractor").Data;

                    var addressResposne = this._cmsDatabase.ContractRepository.CreateAddress(contractor.Address);

                    if (addressResposne.IsExecuted)
                    {
                        return new CreateResponse(true, "Contractor is created");
                    }

                    return new CreateResponse(false, "Contractor cant be created");
                }
            }

            return new CreateResponse(false, "Error");
        }
<<<<<<< HEAD

        public CreateResponse CreateLiability(Liability liability)
         {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(liability.ContractId))
=======
        public CreateResponse CreateLiability(Liability liability, string userToken)
        {
            if (liability.Id != 0)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
            {
                if (liability.Id != 0)
                {
                    var updateLiabilityResponse = this.UpdateLiability(liability);

                    if (updateLiabilityResponse.IsExecuted)
                    {
                        return new CreateResponse(updateLiabilityResponse.IsExecuted, updateLiabilityResponse.Message);
                    }

                    return new CreateResponse(updateLiabilityResponse.IsExecuted, updateLiabilityResponse.Message);
                }

                //liability.ContractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

                var liabilityResponse = this._cmsDatabase.ContractRepository.CreateLiability(liability);

                if (liabilityResponse.IsExecuted)
                {
                    return new CreateResponse(true, liabilityResponse.Message);
                }

                return new CreateResponse(false, liabilityResponse.Message);
            }

            return new CreateResponse(false, "Error");
        }
        public CreateResponse CreateNotification(Notification notification, string userToken)
        {
            if (notification.Id != 0)
            {
                var updateNotificationResponse = this.UpdateNotification(notification);

<<<<<<< HEAD
        public CreateResponse CreateClaim(Claim claim)
=======
                if (updateNotificationResponse.IsExecuted)
                {
                    return new CreateResponse(updateNotificationResponse.IsExecuted, updateNotificationResponse.Message);
                }

                return new CreateResponse(updateNotificationResponse.IsExecuted, updateNotificationResponse.Message);
            }

            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            notification.ContractId = contractId;

            return this._cmsDatabase.ContractRepository.CreateNotification(notification);
        }
        public CreateResponse CreateComment(Comment comment, string userToken)
        {
            if (comment.Id != 0)
            {
                var updateCommentResponse = this.UpdateComment(comment);

                if (updateCommentResponse.IsExecuted)
                {
                    return new CreateResponse(updateCommentResponse.IsExecuted, updateCommentResponse.Message);
                }

                return new CreateResponse(updateCommentResponse.IsExecuted, updateCommentResponse.Message);
            }

            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            comment.ContractId = contractId;

            return this._cmsDatabase.ContractRepository.CreateComment(comment);
        }
        public CreateResponse CreateClaim(Claim claim, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(claim.ContractId))
            {
                if (claim.Id != 0)
                {
                    var updateLiabilityResponse = this.UpdateClaim(claim);

                    if (updateLiabilityResponse.IsExecuted)
                    {
                        return new CreateResponse(updateLiabilityResponse.IsExecuted, updateLiabilityResponse.Message);
                    }

                    return new CreateResponse(updateLiabilityResponse.IsExecuted, updateLiabilityResponse.Message);
                }

                //claim.ContractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

                var liabilityResponse = this._cmsDatabase.ContractRepository.CreateClaim(claim);

                if (liabilityResponse.IsExecuted)
                {
                    return new CreateResponse(true, liabilityResponse.Message);
                }

                return new CreateResponse(false, liabilityResponse.Message);
            }

            return new CreateResponse(false, "Error");
        }
<<<<<<< HEAD

        public ReadResponse<List<LiabilityType>> ReadLiabilityType()
        {
            return this._cmsDatabase.ContractRepository.ReadLiabilityType();
        }

        public ReadResponse<List<Contractor>> ReadContractor(int id)
        {
            //var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken);

            return this._cmsDatabase.ContractRepository.ReadContractor(id);
        }

        public UpdateResponse UpdateContractor(Contractor contractor)
        {
            return this._cmsDatabase.ContractRepository.UpdateContractor(contractor);
        }

        public UpdateResponse UpdateAddress(Address address)
        {
            return this._cmsDatabase.ContractRepository.UpdateAddress(address);
        }

        public UpdateResponse UpdateLiability(Liability liability)
        {
            return this._cmsDatabase.ContractRepository.UpdateLiability(liability);
        }

        public ReadResponse<List<Liability>> ReadLiability(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadLiability(id);
        }

        public UpdateResponse UpdateClaim(Claim claim)
        {
            return this._cmsDatabase.ContractRepository.UpdateClaim(claim);
        }

        public ReadResponse<List<Claim>> ReadClaim(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadClaim(id);
        }

        public ReadResponse<List<DepartmentType>> ReadAllDepartmentType()
        {
            return this._cmsDatabase.ContractRepository.ReadDepartmentType();
        }

        public ReadResponse<List<Department>> ReadDepartment(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadDepartment(id);
        }

        public CreateResponse CreateDepartment(List<Department> departments)
=======
        public CreateResponse CreateDepartment(List<Department> departments, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            var contractId = departments[0].ContractId;

            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(contractId))
            {
                var idCollection = new List<int>();

                for (int index = 0; index < departments.Count; index++)
                {
                    idCollection.Add(departments[index].Id);
                }

                var isOldDepartmentDeleted = this._cmsDatabase.ContractRepository.DeleteDepartments(idCollection).IsExecuted;

                if (isOldDepartmentDeleted)
                {
                    return this._cmsDatabase.ContractRepository.CreateDepartments(departments);
                }

                return new CreateResponse(false, "Departments cant be created!");
            }
            return new CreateResponse(false, "Error");
        }
<<<<<<< HEAD

        public ReadResponse<List<FineType>> ReadFineType()
        {
            return this._cmsDatabase.ContractRepository.ReadFineType();
        }

        public CreateResponse CreateFine(Fine fine)
=======
        public CreateResponse CreateFine(Fine fine, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(fine.ContractId))
            {
                if (fine.Id != 0)
                {
                    var updateFineResponse = this.UpdateFine(fine);

                    if (updateFineResponse.IsExecuted)
                    {
                        return new CreateResponse(updateFineResponse.IsExecuted, updateFineResponse.Message);
                    }

                    return new CreateResponse(updateFineResponse.IsExecuted, updateFineResponse.Message);
                }

                return this._cmsDatabase.ContractRepository.CreateFine(fine);
            }

            return new CreateResponse(false, "Error");
        }

<<<<<<< HEAD
        public ReadResponse<List<Fine>> ReadFine(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadFine(id);
        }

        public UpdateResponse UpdateFine(Fine fine)
        {
            return this._cmsDatabase.ContractRepository.UpdateFine(fine);
        }

        public UpdateResponse UpdateCategory(Category category)
        {
            return this._cmsDatabase.ContractRepository.UpdateCategory(category);
        }

        public ReadResponse<List<CategoryType>> ReadCategoryType()
        {
            return this._cmsDatabase.ContractRepository.ReadCategoryType();
        }

        public ReadResponse<List<Category>> ReadCategory(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadCategory(id);
        }

        public CreateResponse CreateCategory(Category category)
=======
        public CreateResponse CreateCategory(Category category, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(category.ContractId))
            {
                if (category.Id != 0)
                {
                    var updateCategoryResponse = this.UpdateCategory(category);

                    if (updateCategoryResponse.IsExecuted)
                    {
                        return new CreateResponse(updateCategoryResponse.IsExecuted, updateCategoryResponse.Message);
                    }

                    return new CreateResponse(updateCategoryResponse.IsExecuted, updateCategoryResponse.Message);
                }

                return this._cmsDatabase.ContractRepository.CreateCategory(category);
            }

            return new CreateResponse(false, "Error");
        }
<<<<<<< HEAD

        public ReadResponse<List<DutyType>> ReadDutyType()
        {
            return this._cmsDatabase.ContractRepository.ReadDutyType();
        }

        public ReadResponse<List<Duty>> ReadDuty(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadDuty(id);
        }

        public UpdateResponse UpdateDuty(Duty duty)
        {
            return this._cmsDatabase.ContractRepository.UpdateDuty(duty);
        }

        public CreateResponse CreateDuty(Duty duty)
=======
        public CreateResponse CreateDuty(Duty duty, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(duty.ContractId))
            {
                if (duty.Id != 0)
                {
                    var updateDutyResponse = this.UpdateDuty(duty);

                    if (updateDutyResponse.IsExecuted)
                    {
                        return new CreateResponse(updateDutyResponse.IsExecuted, updateDutyResponse.Message);
                    }

                    return new CreateResponse(updateDutyResponse.IsExecuted, updateDutyResponse.Message);
                }

                return this._cmsDatabase.ContractRepository.CreateDuty(duty);
            }

            return new CreateResponse(false, "Error");
        }
<<<<<<< HEAD

        public ReadResponse<List<NotificationType>> ReadNotificationType()
        {
            return this._cmsDatabase.ContractRepository.ReadNotificationType();
        }

        public ReadResponse<List<Notification>> ReadNotification(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadNotification(id);
        }

        public UpdateResponse UpdateNotification(Notification notification)
        {
            return this._cmsDatabase.ContractRepository.UpdateNotification(notification);
        }

        public CreateResponse CreateNotification(Notification notification)
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(notification.ContractId))
            {
                if (notification.Id != 0)
                {
                    var updateNotificationResponse = this.UpdateNotification(notification);

                    if (updateNotificationResponse.IsExecuted)
                    {
                        return new CreateResponse(updateNotificationResponse.IsExecuted, updateNotificationResponse.Message);
                    }

                    return new CreateResponse(updateNotificationResponse.IsExecuted, updateNotificationResponse.Message);
                }

                return this._cmsDatabase.ContractRepository.CreateNotification(notification);
            }

            return new CreateResponse(false, "Error");
        }

        public CreateResponse CreateComment(Comment comment)
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(comment.ContractId))
            {
                if (comment.Id != 0)
                {
                    var updateCommentResponse = this.UpdateComment(comment);

                    if (updateCommentResponse.IsExecuted)
                    {
                        return new CreateResponse(updateCommentResponse.IsExecuted, updateCommentResponse.Message);
                    }

                    return new CreateResponse(updateCommentResponse.IsExecuted, updateCommentResponse.Message);
                }


                return this._cmsDatabase.ContractRepository.CreateComment(comment);
            }

            return new CreateResponse(false, "Error");
        }

        public UpdateResponse UpdateComment(Comment comment)
        {
            return this._cmsDatabase.ContractRepository.UpdateComment(comment);
        }

        public ReadResponse<List<Comment>> ReadComment(int id)
        {
            return this._cmsDatabase.ContractRepository.ReadComment(id);
        }

        public CreateResponse CreateSign(Sign sign)
=======
        public CreateResponse CreateSign(Sign sign, string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            if (this._cmsDatabase.ContractRepository.ReadAllId().Data.Contains(sign.ContractId))
            {
                if (sign.Id != 0)
                {
                    var updateSignResponse = this.UpdateSign(sign);

                    if (updateSignResponse.IsExecuted)
                    {
                        return new CreateResponse(updateSignResponse.IsExecuted, updateSignResponse.Message);
                    }

                    return new CreateResponse(updateSignResponse.IsExecuted, updateSignResponse.Message);
                }

                return this._cmsDatabase.ContractRepository.CreateSign(sign);
            }

            return new CreateResponse(false, "Error");
        }
        public CreateResponse CreateFile(DataFile file, string userToken)
        {
            //if (file.FileId != 0)
            //{
            //    var updateFileResponse = this.UpdateFile(file);

            //    if (updateFileResponse.IsExecuted)
            //    {
            //        return new CreateResponse(updateFileResponse.IsExecuted, updateFileResponse.Message);
            //    }

            //    return new CreateResponse(updateFileResponse.IsExecuted, updateFileResponse.Message);
            //}

            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            file.ContractId = contractId;

            return this._cmsDatabase.ContractRepository.CreateFile(file);
        }

<<<<<<< HEAD
        public ReadResponse<List<Sign>> ReadSign(int id)
=======

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public ReadResponse<List<ContractType>> ReadAllContractType()
        {
            return this._cmsDatabase.ContractRepository.ReadContractType();
        }
        public ReadResponse<List<ContractStatus>> ReadAllContractStatus()
        {
            return this._cmsDatabase.ContractRepository.ReadContractStatusType();
        }
        public ReadResponse<Info> ReadInfoByUserToken(string userToken)
        {
            return this._cmsDatabase.ContractRepository.ReadInfoByUserToken(userToken);
        }
        public ReadResponse<List<LiabilityType>> ReadLiabilityType()
        {
            return this._cmsDatabase.ContractRepository.ReadLiabilityType();
        }
        public ReadResponse<List<Contractor>> ReadContractor(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken);

            return this._cmsDatabase.ContractRepository.ReadContractor(contractId.Data);
        }
        public ReadResponse<List<Claim>> ReadClaim(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadClaim(contractId);
        }
        public ReadResponse<List<DepartmentType>> ReadAllDepartmentType()
        {
            return this._cmsDatabase.ContractRepository.ReadDepartmentType();
        }
        public ReadResponse<List<Department>> ReadDepartment(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadDepartment(contractId);
        }
        public ReadResponse<List<Fine>> ReadFine(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadFine(contractId);
        }

        public ReadResponse<List<CategoryType>> ReadCategoryType()
        {
            return this._cmsDatabase.ContractRepository.ReadCategoryType();
        }
        public ReadResponse<List<Category>> ReadCategory(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadCategory(contractId);
        }
        public ReadResponse<List<DutyType>> ReadDutyType()
        {
            return this._cmsDatabase.ContractRepository.ReadDutyType();
        }
        public ReadResponse<List<Duty>> ReadDuty(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadDuty(contractId);
        }
        public ReadResponse<List<NotificationType>> ReadNotificationType()
        {
            return this._cmsDatabase.ContractRepository.ReadNotificationType();
        }
        public ReadResponse<List<Notification>> ReadNotification(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadNotification(contractId);
        }
        public ReadResponse<List<Sign>> ReadSign(string userToken)
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        {
            return this._cmsDatabase.ContractRepository.ReadSign(id);
        }
        public ReadResponse<bool> IsContractActive(string userToken)
        {
            return this._cmsDatabase.ContractRepository.IsContractActive(userToken);
        }
<<<<<<< HEAD

        public ReadResponse<bool> IsContractActive(int id)
        {
            return this._cmsDatabase.ContractRepository.IsContractActive(id);
        }

        public ReadResponse<List<int>> ReadAllId()
        {
            return this._cmsDatabase.ContractRepository.ReadAllId();
        }

        public ReadResponse<List<Contract>> ReadAllContract() 
        {
            return this._cmsDatabase.ContractRepository.ReadAllContract();
        }

        public ReadResponse<List<Contract>> ReadLike(string text)
        {
            return this._cmsDatabase.ContractRepository.ReadLike(text);
=======
        public ReadResponse<List<Liability>> ReadLiability(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadLiability(contractId);
        }
        public ReadResponse<List<Comment>> ReadComment(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadComment(contractId);
        }
        public ReadResponse<List<FineType>> ReadFineType()
        {
            return this._cmsDatabase.ContractRepository.ReadFineType();
        }
        public ReadResponse<List<File>> ReadFile(string userToken)
        {
            var contractId = this._cmsDatabase.ContractRepository.ReadContractIdByUsertoken(userToken).Data;

            return this._cmsDatabase.ContractRepository.ReadFile(contractId);
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        public UpdateResponse UpdateContractStatus(string userToken)
        {
            return this._cmsDatabase.ContractRepository.UpdateContractStatus(userToken);
        }
        public UpdateResponse UpdateContractor(Contractor contractor)
        {
            return this._cmsDatabase.ContractRepository.UpdateContractor(contractor);
        }
        public UpdateResponse UpdateAddress(Address address)
        {
            return this._cmsDatabase.ContractRepository.UpdateAddress(address);
        }
        public UpdateResponse UpdateFine(Fine fine)
        {
            return this._cmsDatabase.ContractRepository.UpdateFine(fine);
        }
        public UpdateResponse UpdateCategory(Category category)
        {
            return this._cmsDatabase.ContractRepository.UpdateCategory(category);
        }
        public UpdateResponse UpdateLiability(Liability liability)
        {
            return this._cmsDatabase.ContractRepository.UpdateLiability(liability);
        }
        public UpdateResponse UpdateSign(Sign sign)
        {
            return this._cmsDatabase.ContractRepository.UpdateSign(sign);
        }
        public UpdateResponse UpdateClaim(Claim claim)
        {
            return this._cmsDatabase.ContractRepository.UpdateClaim(claim);
        }
        public UpdateResponse UpdateNotification(Notification notification)
        {
            return this._cmsDatabase.ContractRepository.UpdateNotification(notification);
        }
        public UpdateResponse UpdateComment(Comment comment)
        {
            return this._cmsDatabase.ContractRepository.UpdateComment(comment);
        }
        public UpdateResponse UpdateDuty(Duty duty)
        {
            return this._cmsDatabase.ContractRepository.UpdateDuty(duty);
        }
        public UpdateResponse UpdateFile(File file)
        {
            return this._cmsDatabase.ContractRepository.UpdateFile(file);
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        public DeleteResponse DeleteLiability(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteLiabilityById(id);
        }
        public DeleteResponse DeleteClaim(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteClaimById(id);
        }
        public DeleteResponse DeleteDepartment(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteDepartmentById(id);
        }
        public DeleteResponse DeleteCategory(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteCategoryById(id);
        }
        public DeleteResponse DeleteFine(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteFineById(id);
        }
        public DeleteResponse DeleteDuty(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteDutyById(id);
        }
        public DeleteResponse DeleteNotification(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteNotificationById(id);
        }
        public DeleteResponse DeleteComment(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteCommentById(id);
        }
        public DeleteResponse DeleteSign(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteSignById(id);
        }
        public DeleteResponse DeleteFile(int id)
        {
            return this._cmsDatabase.ContractRepository.DeleteFileById(id);
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        }
    }
}