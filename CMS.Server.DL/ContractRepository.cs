namespace CMS.Server.DL
{
    using System;
    using CMS.Server.Model;
    using CMS.Server.DL.DBConfig;
    using System.Collections.Generic;
    using CMS.Server.Model.DBResponses;
    using System.Data;
    using Npgsql;

    public class ContractRepository : CMSDBConnection, IContractRepository
    {
        private readonly DBConfigData _configData;

        public ContractRepository(DBConfigData configData) : base(configData)
        {
            this._configData = configData;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public CreateResponse CreateAddress(Address address)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            address(street, postalcode, city, housenumber, contractorid)
                            values(@Street, @PostalCode, @City, @HouseNumber, @ContractorId)";


                    cmd.Parameters.Add(new NpgsqlParameter("@Street", address.Street));
                    cmd.Parameters.Add(new NpgsqlParameter("@HouseNumber", address.HouseNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@PostalCode", address.PostalCode));
                    cmd.Parameters.Add(new NpgsqlParameter("@City", address.City));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractorId", address.ContractorId));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Address data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Address data has been added successfully.");
            }

        }
        public CreateResponse CreateContract(Contract contract)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            contract(status)
                            values(@Status)";

                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "active"));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    return new CreateResponse(true, Convert.ToString(this.GetLastId("contract").Data));
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error new contract cant be added.");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public CreateResponse CreateInfo(Info info)
        {
            if (info.ProjectName is null)
            {
                info.ProjectName = "empty";
            }

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            info(contractid, contractstatusid, contracttypeid,  istemporary, startdate, enddate, terminationperiod, expdate, isreferenced ,projectid, projectname, comment)
                            values(@ContractId, @ContractStatusId, @ContractTypeId, @IsTemporary, @StartDate, @EndDate, @TerminationPeriod ,@ExpDate, @IsReferenceToAnotherProject,@ProjectId, @ProjectName, @Comment)";


                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", info.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractStatusId", info.ContractStatusId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractTypeId", info.ContractTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsTemporary", info.IsTemporary));
                    cmd.Parameters.Add(new NpgsqlParameter("@StartDate", info.StartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@EndDate", info.EndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@TerminationPeriod", info.TerminationPeriod));
                    cmd.Parameters.Add(new NpgsqlParameter("@ExpDate", info.ExpDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsReferenceToAnotherProject", info.IsReferencedToAnotherProject));
                    cmd.Parameters.Add(new NpgsqlParameter("@ProjectId", info.ProjectId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ProjectName", info.ProjectName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", info.Comment));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new CreateResponse(false, "Due to some error info data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Info data has been added successfully.");
            }

        }
<<<<<<< HEAD

        // Finished.
        public ReadResponse<bool> HasInfoAlreadyCreated(int contractId)
        {
            bool isFound = false;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from info where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", contractId));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isFound = true;
                    }
                    cmd.Dispose();

                    return new ReadResponse<bool>(true, "Id is fetched successfully", isFound);
                }
                catch (Exception ex)
                {
                    return new ReadResponse<bool>(false, "Id cant be fetched", isFound);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public ReadResponse<bool> Exists(int id, string table)
        {
            bool isFound = false;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * from {table} where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isFound = true;
                    }
                    cmd.Dispose();

                    return new ReadResponse<bool>(true, "Id is fetched successfully", isFound);
                }
                catch (Exception ex)
                {
                    return new ReadResponse<bool>(false, "Id cant be fetched", isFound);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Finished.
        public UpdateResponse UpdateInfo(Info info)
        {
            if (info.ProjectName is null)
            {
                info.ProjectName = "empty";
            }

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update info set \"contractid\"=@ContractId, \"contractstatusid\"=@ContractStatusId, \"contracttypeid\"=@ContractTypeId, \"istemporary\"=@IsTemporary, \"startdate\"=@StartDate, \"enddate\"=@EndDate, \"terminationperiod\"=@TerminationPeriod, \"expdate\"=@ExpDate, \"isreferenced\"=@IsReferenceToAnotherProject, \"projectid\"=@ProjectId, \"projectname\"=@ProjectName, \"comment\"=@Comment  WHERE \"contractid\"=@ContractId;";

                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", info.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractStatusId", info.ContractStatusId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractTypeId", info.ContractTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsTemporary", info.IsTemporary));
                    cmd.Parameters.Add(new NpgsqlParameter("@StartDate", info.StartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@EndDate", info.EndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@TerminationPeriod", info.TerminationPeriod));
                    cmd.Parameters.Add(new NpgsqlParameter("@ExpDate", info.ExpDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsReferenceToAnotherProject", info.IsReferencedToAnotherProject));
                    cmd.Parameters.Add(new NpgsqlParameter("@ProjectId", info.ProjectId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ProjectName", info.ProjectName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", info.Comment));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error info data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "Info data has been added successfully.");
            }
        }
        public CreateResponse CreateAddress(Address address)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            address(street, postalcode, city, housenumber, contractorid)
                            values(@Street, @PostalCode, @City, @HouseNumber, @ContractorId)";


                    cmd.Parameters.Add(new NpgsqlParameter("@Street", address.Street));
                    cmd.Parameters.Add(new NpgsqlParameter("@HouseNumber", address.HouseNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@PostalCode", address.PostalCode));
                    cmd.Parameters.Add(new NpgsqlParameter("@City", address.City));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractorId", address.ContractorId));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Address data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Address data has been added successfully.");
            }

        }

        // Finished.
        public ReadResponse<int> GetLastId(string tableName)
        {
            int id = 0;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * from {tableName}";
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (Convert.ToInt32((reader[0].ToString())) > id)
                        {
                            id = Convert.ToInt32((reader[0].ToString()));
                        }
                    }
                    cmd.Dispose();

                    return new ReadResponse<int>(true, "last id is fetched", id);
                }
                catch (Exception ex)
                {
                    return new ReadResponse<int>(false, "last id cant be fetched", -1);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

=======
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
        public CreateResponse CreateContractor(Contractor contractor)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            contractor(contractid, companyname , person, department, email, telnumber,companyregistrationnumber )
                            values(@ContractId, @CompanyName, @Person , @Department, @Email, @TelNumber, @CompanyRegistrationNumber)";

                    cmd.Parameters.Add(new NpgsqlParameter("@CompanyName", contractor.CompanyName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Person", contractor.Person));
                    cmd.Parameters.Add(new NpgsqlParameter("@CompanyRegistrationNumber", contractor.CompanyRegistrationNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@Department", contractor.Department));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", contractor.Email));
                    cmd.Parameters.Add(new NpgsqlParameter("@TelNumber", contractor.TelNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", contractor.ContractId));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new CreateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "contractor data has been added successfully.");
            }
        }
        public CreateResponse CreateLiability(Liability liability)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            liability(liabilitytypeid, contractid, duedate, cost)
                            values(@LiabilityTypeId, @ContractId, @DueDate, @Cost)";

                    cmd.Parameters.Add(new NpgsqlParameter("@DueDate", liability.DueDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@LiabilityTypeId", liability.PaymentPeriodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Cost", liability.Cost));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", liability.ContractId));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error liability data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "liability data has been added successfully.");
            }
        }
        public CreateResponse CreateClaim(Claim claim)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            claim(claimtypeid, contractid, duedate, cost)
                            values(@ClaimTypeId, @ContractId, @DueDate, @Cost)";



                    cmd.Parameters.Add(new NpgsqlParameter("@DueDate", claim.DueDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@ClaimTypeId", claim.PaymentPeriodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Cost", claim.Cost));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", claim.ContractId));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error claim data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "claim data has been added successfully.");
            }
        }
        public CreateResponse CreateDepartment(Department department)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            department(contractid, departmenttypeid , personname)
                            values(@ContractId, @DepartmentTypeId, @PersonName)";


                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", department.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@DepartmentTypeId", department.DepartmentTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@PersonName", department.PersonName));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Department data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Department data has been added successfully.");
            }
        }
        public CreateResponse CreateFine(Fine fine)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            fine(contractid, finetypeid, price, comment)
                            values(@ContractId, @FineTypeId , @Price , @Comment)";


                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", fine.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@FineTypeId", fine.FineTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Price", fine.Price));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", fine.Comment));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new CreateResponse(false, "Due to some error Fine data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Fine data has been added successfully.");
            }
        }
        public CreateResponse CreateDepartments(List<Department> departments)
        {
            bool isCreated = false;

            foreach (var department in departments)
            {
                isCreated = this.CreateDepartment(department).IsExecuted;
            }

            if (isCreated)
            {
                return new CreateResponse(true, "Departments are created.");
            }

            return new CreateResponse(false, "Departments cant be created.");
        }
        public CreateResponse CreateCategory(Category category)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            category(contractid, categorytypeid, comment)
                            values(@ContractId, @CategoryTypeId, @Comment)";


                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", category.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@CategoryTypeId", category.CategoryTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", category.Comment));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Category data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Category data has been added successfully.");

            }
        }
        public CreateResponse CreateDuty(Duty duty)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            duty(date, dutytypeid, comment, contractid)
                            values(@Date, @DutyTypeId, @Comment, @ContractId)";


                    cmd.Parameters.Add(new NpgsqlParameter("@Date", duty.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@DutyTypeId", duty.DutyTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", duty.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", duty.ContractId));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new CreateResponse(false, "Due to some error duty data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "duty data has been added successfully.");
            }
        }
        public CreateResponse CreateNotification(Notification notification)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            notification(notificationtypeid, contractid, date, email, isrepeatitionallowed)
                            values(@NotificationTypeId, @ContractId, @Date, @Email, @IsRepeatitionAllowed)";


                    cmd.Parameters.Add(new NpgsqlParameter("@NotificationTypeId", notification.NotificationTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", notification.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", notification.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", notification.Email));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsRepeatitionAllowed", notification.IsRepeatitionAllowed));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Notification data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Notification data has been added successfully.");

            }

        }
        public CreateResponse CreateComment(Comment comment)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            comment(contractid, text, date, username)
                            values(@ContractId, @Text, @Date, @Username)";


                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", comment.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Text", comment.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", comment.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@Username", comment.Username));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Comment data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Comment data has been added successfully.");

            }
        }
        public CreateResponse CreateSign(Sign sign)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            sign(firstname, lastname, date, issigned, iscompletlysigned, contractid)
                            values(@Firstname, @Lastname, @Date, @IsSigned, @IsCompletlySigned, @ContractId)";


                    cmd.Parameters.Add(new NpgsqlParameter("@Firstname", sign.FirstName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Lastname", sign.LastName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", sign.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsSigned", sign.IsSigned));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsCompletlySigned", sign.IsCompletlySigned));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", sign.ContractId));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new CreateResponse(false, "Due to some error Sign data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "Sign data has been added successfully.");

            }
        }
        public CreateResponse CreateFile(DataFile file)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = @"insert into 
                            file(filename, date, comment, isfinal, contractid, data)
                            values(@FileName, @Date , @Comment , @IsFinal , @ContractId , @Data)";

                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", file.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@FileName", file.FileName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", file.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", file.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsFinal", file.IsFinal));
                    cmd.Parameters.Add(new NpgsqlParameter("@Data", file.Data));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new CreateResponse(false, "Due to some error File data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new CreateResponse(true, "File data has been added successfully.");
            }
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public ReadResponse<bool> HasInfoAlreadyCreated(int contractId)
        {
            bool isFound = false;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from info where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", contractId));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isFound = true;
                    }
                    cmd.Dispose();

                    return new ReadResponse<bool>(true, "Id is fetched successfully", isFound);
                }
                catch (Exception ex)
                {
                    return new ReadResponse<bool>(false, "Id cant be fetched", isFound);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<int> GetLastId(string tableName)
        {
            int id = 0;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * from {tableName}";
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (Convert.ToInt32((reader[0].ToString())) > id)
                        {
                            id = Convert.ToInt32((reader[0].ToString()));
                        }
                    }
                    cmd.Dispose();

                    return new ReadResponse<int>(true, "last id is fetched", id);
                }
                catch (Exception ex)
                {
                    return new ReadResponse<int>(false, "last id cant be fetched", -1);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<int> ReadContractIdByUsertoken(string userToken)
        {
            int id = 0;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from contract where usertoken = @Usertoken AND status = @Status";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@Usertoken", userToken));
                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "active"));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader[0].ToString());

                    }
                    cmd.Dispose();

                    return new ReadResponse<int>(true, "Id is fetched successfully", id);
                }
                catch (Exception ex)
                {
                    return new ReadResponse<int>(false, "Id cant be fetched", 0);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<Info> ReadInfoById(int id)
        {
            if (id != 0)
            {
                var info = this.ReadInfo().Data.Find(x => x.ContractId == id);

                if (info != null)
                {
                    return new ReadResponse<Info>(true, "Info is fetched successfully", info);
                }
            }

            return new ReadResponse<Info>(false, "Info cant be fetched", null);
        }
        public ReadResponse<List<ContractStatus>> ReadContractStatusType()
        {
            List<ContractStatus> allStatus = new List<ContractStatus>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from contractstatus";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        string status = reader[1].ToString();

                        allStatus.Add(new ContractStatus(id, status));
                    }
                    cmd.Dispose();

                    return new(true, "StatusType are fetched successfully", allStatus);
                }
                catch (Exception ex)
                {
                    return new(false, "StatusType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<ContractType>> ReadContractType()
        {
            List<ContractType> ContractTypes = new List<ContractType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from contracttype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int contract_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        ContractTypes.Add(new ContractType(contract_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "ContractType are fetched successfully", ContractTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "ContractType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Info>> ReadInfo()
        {
            List<Info> infos = new List<Info>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from info";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bool is_temporary = Convert.ToBoolean(reader[1].ToString());
                        DateTime start_date = Convert.ToDateTime(reader[2].ToString());
                        DateTime end_date = Convert.ToDateTime(reader[3].ToString());
                        string termination_period = reader[4].ToString();
                        DateTime exp_date = Convert.ToDateTime(reader[5].ToString());
                        bool is_reference_to_another_project = Convert.ToBoolean(reader[6].ToString());
                        int project_id = Convert.ToInt32(reader[7].ToString());
                        string project_name = reader[8].ToString();
                        string comment = reader[9].ToString();
                        int contractId = Convert.ToInt32(reader[10].ToString());
                        int contract_status_id = Convert.ToInt32(reader[11].ToString());
                        int contract_type_id = Convert.ToInt32(reader[12].ToString());

                        infos.Add(new Info(contractId, contract_status_id, contract_type_id, is_temporary, start_date, end_date, termination_period, exp_date, is_reference_to_another_project, project_id, project_name, comment));
                    }
                    cmd.Dispose();

                    return new(true, "Infos are fetched successfully", infos);
                }
                catch (Exception ex)
                {
                    return new(false, "Infos are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<Info> ReadLastInfo()
        {

            Info info = null;
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from info where contract_id = (select MAX(contract_id) from info)";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        int contract_status_type_id = Convert.ToInt32(reader[1].ToString());
                        int contract_type_id = Convert.ToInt32(reader[2].ToString());
                        bool is_temporary = Convert.ToBoolean(reader[3].ToString());
                        DateTime start_date = Convert.ToDateTime(reader[4].ToString());
                        DateTime end_date = Convert.ToDateTime(reader[5].ToString());
                        string termination_period = reader[6].ToString();
                        DateTime exp_date = Convert.ToDateTime(reader[7].ToString());
                        bool is_reference_to_another_project = Convert.ToBoolean(reader[8].ToString());
                        int project_id = Convert.ToInt32(reader[9].ToString());
                        string project_name = reader[10].ToString();
                        string comment = reader[11].ToString();

                        info = new Info(id, contract_status_type_id, contract_type_id, is_temporary, start_date, end_date, termination_period, exp_date, is_reference_to_another_project, project_id, project_name, comment);
                    }
                    cmd.Dispose();

                    return new(true, "Infos are fetched successfully", info);
                }
                catch (Exception ex)
                {
                    return new(false, "Infos are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Address>> ReadAddress()
        {
            List<Address> addresses = new List<Address>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from address";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int address_id = Convert.ToInt32(reader[0].ToString());
                        string street = reader[1].ToString();
                        int postal_code = Convert.ToInt32(reader[2].ToString());
                        string city = reader[3].ToString();
                        string house_number = reader[4].ToString();
                        int contractorId = Convert.ToInt32(reader[5].ToString());


                        addresses.Add(new Address(address_id, street, house_number, postal_code, city, contractorId));
                    }
                    cmd.Dispose();

                    return new(true, "Addresses are fetched successfully", addresses);
                }
                catch (Exception ex)
                {
                    return new(false, "Addresses are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Contractor>> ReadContractor(int id)
        {
            var contractors = new List<Contractor>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from contractor where contractid = @ContractID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int contractor_id = Convert.ToInt32(reader[0].ToString());
                        int contract_id = Convert.ToInt32(reader[1].ToString());
                        string company_name = reader[2].ToString();
                        string person = reader[3].ToString();
                        string department = reader[4].ToString();
                        string email = reader[5].ToString();
                        string tel_number = reader[6].ToString();
                        string company_registration_number = reader[7].ToString();

                        var contractorAddress = this.ReadAddress().Data.Find(x => x.ContractorId == contractor_id);

                        contractors.Add(new Contractor(contractor_id, company_name, person, company_registration_number, department, contractorAddress, email, tel_number, contract_id));
                    }
                    cmd.Dispose();

                    return new(true, "Contractors are fetched successfully", contractors);
                }
                catch (Exception ex)
                {
                    return new(false, "Contractors are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<LiabilityType>> ReadLiabilityType()
        {
            List<LiabilityType> liabilityTypes = new List<LiabilityType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from liabilitytype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int liability_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        liabilityTypes.Add(new LiabilityType(liability_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "LiabilityType are fetched successfully", liabilityTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "LiabilityType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Liability>> ReadLiability(int id)
        {
            List<Liability> Liabilities = new List<Liability>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from liability where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int liability_id = Convert.ToInt32(reader[0].ToString());
                        int liability_type_id = Convert.ToInt32(reader[1].ToString());
                        int contract_id = Convert.ToInt32(reader[2].ToString());
                        DateTime due_date = Convert.ToDateTime(reader[3].ToString());
                        double cost = Convert.ToDouble(reader[4].ToString());


                        Liabilities.Add(new Liability(liability_id, due_date, liability_type_id, cost, contract_id));
                    }
                    cmd.Dispose();

                    return new(true, "Liability are fetched successfully", Liabilities);
                }
                catch (Exception ex)
                {
                    return new(false, "Liability are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<ClaimType>> ReadClaimType()
        {
            List<ClaimType> claimTypes = new List<ClaimType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from claim_type";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int claim_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        claimTypes.Add(new ClaimType(claim_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "ClaimType are fetched successfully", claimTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "ClaimType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Claim>> ReadClaim(int id)
        {
            List<Claim> claims = new List<Claim>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from claim where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int claim_id = Convert.ToInt32(reader[0].ToString());
                        int claim_type_id = Convert.ToInt32(reader[1].ToString());
                        int contract_id = Convert.ToInt32(reader[2].ToString());
                        DateTime due_date = Convert.ToDateTime(reader[3].ToString());
                        double cost = Convert.ToDouble(reader[4].ToString());


                        claims.Add(new Claim(claim_id, due_date, claim_type_id, cost, contract_id));
                    }
                    cmd.Dispose();

                    return new(true, "Claim are fetched successfully", claims);
                }
                catch (Exception ex)
                {
                    return new(false, "Claim are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<DepartmentType>> ReadDepartmentType()
        {
            List<DepartmentType> departmentTypes = new List<DepartmentType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from departmenttype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int department_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        departmentTypes.Add(new DepartmentType(department_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "DepartmentType are fetched successfully", departmentTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "DepartmentType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Department>> ReadDepartment(int id)
        {
            List<Department> departments = new List<Department>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from department where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int department_id = Convert.ToInt32(reader[0].ToString());
                        int contact_id = Convert.ToInt32(reader[1].ToString());
                        int department_type_id = Convert.ToInt32(reader[2].ToString());
                        string person_name = reader[3].ToString();


                        departments.Add(new Department(department_id, contact_id, department_type_id, person_name));
                    }
                    cmd.Dispose();

                    return new(true, "Department are fetched successfully", departments);
                }
                catch (Exception ex)
                {
                    return new(false, "Department are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<FineType>> ReadFineType()
        {
            List<FineType> fineTypes = new List<FineType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from finetype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int fine_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        fineTypes.Add(new FineType(fine_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "FineType are fetched successfully", fineTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "FineType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Fine>> ReadFine(int id)
        {
            List<Fine> departments = new List<Fine>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from fine where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int fine_id = Convert.ToInt32(reader[0].ToString());
                        int fine_type_id = Convert.ToInt32(reader[1].ToString());
                        double price = Convert.ToDouble(reader[2].ToString());
                        string comment = reader[3].ToString();
                        int contact_id = Convert.ToInt32(reader[4].ToString());

                        departments.Add(new Fine(fine_id, fine_type_id, price, comment, contact_id));
                    }
                    cmd.Dispose();

                    return new(true, "Fine are fetched successfully", departments);
                }
                catch (Exception ex)
                {
                    return new(false, "Fine are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<CategoryType>> ReadCategoryType()
        {
            List<CategoryType> categoryTypes = new List<CategoryType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from categorytype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int category_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        categoryTypes.Add(new CategoryType(category_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "CategoryType are fetched successfully", categoryTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "CategoryType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Category>> ReadCategory(int id)
        {
            List<Category> categories = new List<Category>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from category where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int category_id = Convert.ToInt32(reader[0].ToString());
                        int category_type_id = Convert.ToInt32(reader[1].ToString());
                        int contract_id = Convert.ToInt32(reader[2].ToString());
                        string comment = reader[3].ToString();

                        categories.Add(new Category(category_id, contract_id, category_type_id, comment));
                    }
                    cmd.Dispose();

                    return new(true, "Fine are fetched successfully", categories);
                }
                catch (Exception ex)
                {
                    return new(false, "Fine are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<DutyType>> ReadDutyType()
        {
            List<DutyType> dutyTypes = new List<DutyType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from dutytype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int due_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        dutyTypes.Add(new DutyType(due_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "DutyType are fetched successfully", dutyTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "DutyType are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Duty>> ReadDuty(int id)
        {
            List<Duty> duties = new List<Duty>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from duty where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int duty_id = Convert.ToInt32(reader[0].ToString());
                        int contract_id = Convert.ToInt32(reader[1].ToString());
                        int duty_type_id = Convert.ToInt32(reader[2].ToString());
                        DateTime duty_date = Convert.ToDateTime(reader[3].ToString());
                        string comment = reader[4].ToString();

                        duties.Add(new Duty(duty_id, duty_date, duty_type_id, comment, contract_id));
                    }
                    cmd.Dispose();

                    return new(true, "Fine are fetched successfully", duties);
                }
                catch (Exception ex)
                {
                    return new(false, "Fine are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<NotificationType>> ReadNotificationType()
        {
            var NotificationTypes = new List<NotificationType>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from notificationtype";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int due_type_id = Convert.ToInt32(reader[0].ToString());
                        string type = reader[1].ToString();

                        NotificationTypes.Add(new NotificationType(due_type_id, type));
                    }
                    cmd.Dispose();

                    return new(true, "Notification Types are fetched successfully", NotificationTypes);
                }
                catch (Exception ex)
                {
                    return new(false, "Notification Types are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Notification>> ReadNotification(int id)
        {
            var notification = new List<Notification>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from notification where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int notificationId = Convert.ToInt32(reader[0].ToString());
                        int notificationTypeId = Convert.ToInt32(reader[1].ToString());
                        int contractId = Convert.ToInt32(reader[2].ToString());
                        DateTime date = Convert.ToDateTime(reader[3].ToString());
                        string email = reader[4].ToString();
                        bool isRepeatitionAllowed = Convert.ToBoolean(reader[5].ToString());

                        notification.Add(new Notification(notificationId, date, notificationTypeId, email, isRepeatitionAllowed, contractId));
                    }
                    cmd.Dispose();

                    return new(true, "Notifications are fetched successfully", notification);
                }
                catch (Exception ex)
                {
                    return new(false, "Notifications cant be fetched.", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Comment>> ReadComment(int id)
        {
            var comments = new List<Comment>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from comment where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int commentId = Convert.ToInt32(reader[0].ToString());
                        int contractId = Convert.ToInt32(reader[1].ToString());
                        string text = reader[2].ToString();
                        DateTime date = Convert.ToDateTime(reader[3].ToString());
                        string username = reader[4].ToString();

                        comments.Add(new Comment(commentId, text, date, username, contractId));
                    }
                    cmd.Dispose();

                    return new(true, "Comments are fetched successfully", comments);
                }
                catch (Exception ex)
                {
                    return new(false, "Comments cant be fetched.", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<Sign>> ReadSign(int id)
        {
            var signs = new List<Sign>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from sign where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int signId = Convert.ToInt32(reader[0].ToString());
                        string firstname = reader[1].ToString();
                        string lastname = reader[2].ToString();
                        DateTime date = Convert.ToDateTime(reader[3].ToString());
                        bool isSigned = Convert.ToBoolean(reader[4].ToString());
                        bool isCompletlySigned = Convert.ToBoolean(reader[5].ToString());
                        int contractId = Convert.ToInt32(reader[6].ToString());

                        signs.Add(new Sign(signId, date, firstname, lastname, isSigned, isCompletlySigned, contractId));
                    }
                    cmd.Dispose();

                    return new(true, "Comments are fetched successfully", signs);
                }
                catch (Exception ex)
                {
                    return new(false, "Comments cant be fetched.", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<bool> IsContractActive(string userToken)
        {
            bool isActive = false;

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select status from contract where usertoken = @Usertoken AND status = @Status";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@UserToken", userToken));
                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "active"));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isActive = true;
                    }

                    cmd.Dispose();

                    if (isActive)
                    {
                        return new(true, "Contract is active", true);
                    }

                    return new(true, "Contract is already inactive", false);

                }
                catch (Exception ex)
                {
                    return new(false, "Comments cant be fetched.", false);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public ReadResponse<List<File>> ReadFile(int id)
        {
            List<File> files = new List<File>();

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from file where contractid = @ContractId";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int file_id = Convert.ToInt32(reader[0].ToString());
                        string file_name = reader[1].ToString();
                        DateTime date = Convert.ToDateTime(reader[2].ToString());
                        string comment = reader[3].ToString();
                        bool is_final = Convert.ToBoolean(reader[4].ToString());
                        int contact_id = Convert.ToInt32(reader[5].ToString());

                        files.Add(new File(file_id, file_name, date, comment, is_final, contact_id));
                    }
                    cmd.Dispose();

                    return new(true, "File are fetched successfully", files);
                }
                catch (Exception ex)
                {
                    return new(false, "File are fetched Unsuccessfully", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public UpdateResponse UpdateInfo(Info info)
        {
            if (info.ProjectName is null)
            {
                info.ProjectName = "empty";
            }

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update info set \"contractid\"=@ContractId, \"contractstatusid\"=@ContractStatusId, \"contracttypeid\"=@ContractTypeId, \"istemporary\"=@IsTemporary, \"startdate\"=@StartDate, \"enddate\"=@EndDate, \"terminationperiod\"=@TerminationPeriod, \"expdate\"=@ExpDate, \"isreferenced\"=@IsReferenceToAnotherProject, \"projectid\"=@ProjectId, \"projectname\"=@ProjectName, \"comment\"=@Comment  WHERE \"contractid\"=@ContractId;";

                    cmd.Parameters.Add(new NpgsqlParameter("@ContractId", info.ContractId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractStatusId", info.ContractStatusId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractTypeId", info.ContractTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsTemporary", info.IsTemporary));
                    cmd.Parameters.Add(new NpgsqlParameter("@StartDate", info.StartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@EndDate", info.EndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@TerminationPeriod", info.TerminationPeriod));
                    cmd.Parameters.Add(new NpgsqlParameter("@ExpDate", info.ExpDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsReferenceToAnotherProject", info.IsReferencedToAnotherProject));
                    cmd.Parameters.Add(new NpgsqlParameter("@ProjectId", info.ProjectId));
                    cmd.Parameters.Add(new NpgsqlParameter("@ProjectName", info.ProjectName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", info.Comment));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error info data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "Info data has been added successfully.");
            }
        }
        public UpdateResponse UpdateAddress(Address address)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update address set \"street\"=@Street, \"postalcode\"=@PostalCode, \"city\"=@City, \"housenumber\"=@HouseNumber WHERE \"contractorid\"=@ContractorId;";

                    cmd.Parameters.Add(new NpgsqlParameter("@ContractorId", address.ContractorId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Street", address.Street));
                    cmd.Parameters.Add(new NpgsqlParameter("@HouseNumber", address.HouseNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@PostalCode", address.PostalCode));
                    cmd.Parameters.Add(new NpgsqlParameter("@City", address.City));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    return new UpdateResponse(false, "Due to some error Address data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "Info data has been added successfully.");
            }
        }
        public UpdateResponse UpdateContractor(Contractor contractor)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update contractor set \"companyname\"=@CompanyName, \"person\"=@Person, \"department\"=@Department, \"email\"=@Email, \"telnumber\"=@TelNumber, \"companyregistrationnumber\"=@CompanyRegistrationNumber WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@CompanyName", contractor.CompanyName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Person", contractor.Person));
                    cmd.Parameters.Add(new NpgsqlParameter("@CompanyRegistrationNumber", contractor.CompanyRegistrationNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@Department", contractor.Department));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", contractor.Email));
                    cmd.Parameters.Add(new NpgsqlParameter("@TelNumber", contractor.TelNumber));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", contractor.Id));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateLiability(Liability liability)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {

                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update liability set \"liabilitytypeid\"=@LiabilityTypeId,\"duedate\"=@DueDate, \"cost\"=@Cost WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@DueDate", liability.DueDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@LiabilityTypeId", liability.PaymentPeriodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Cost", liability.Cost));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", liability.Id));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateClaim(Claim claim)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {

                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update claim set \"claimtypeid\"=@ClaimTypeId,\"duedate\"=@DueDate, \"cost\"=@Cost WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@DueDate", claim.DueDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@ClaimTypeId", claim.PaymentPeriodId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Cost", claim.Cost));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", claim.Id));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateFine(Fine fine)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update fine set \"finetypeid\"=@FineTypeId,\"price\"=@Price, \"comment\"=@Comment WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@FineTypeId", fine.FineTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Price", fine.Price));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", fine.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", fine.Id));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateCategory(Category category)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update category set \"categorytypeid\"=@CategoryTypeId,\"comment\"=@Comment WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@CategoryTypeId", category.CategoryTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", category.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", category.Id));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateNotification(Notification notification)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update notification set \"notificationtypeid\"=@NotificationTypeId,\"date\"=@Date,\"email\"=@Email,\"isrepeatitionallowed\"=@IsRepeatitionAllowed WHERE \"id\"=@Id;";


                    cmd.Parameters.Add(new NpgsqlParameter("@NotificationTypeId", notification.NotificationTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", notification.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", notification.Email));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsRepeatitionAllowed", notification.IsRepeatitionAllowed));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", notification.Id));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateComment(Comment comment)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update comment set \"text\"=@Text,\"date\"=@Date,\"username\"=@Username WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@Text", comment.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", comment.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@Username", comment.Username));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", comment.Id));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateContractStatus(string userToken)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update contract set \"status\"=@Status WHERE \"usertoken\"=@UserToken;";

                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "inactive"));
                    cmd.Parameters.Add(new NpgsqlParameter("@UserToken", userToken));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some reason status cant be changed.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "status has been changed successfully.");
            }
        }
        public UpdateResponse UpdateDuty(Duty duty)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update duty set \"date\"=@Date,\"dutytypeid\"=@Dutytypeid,\"comment\"=@Comment WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@Date", duty.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@DutyTypeId", duty.DutyTypeId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", duty.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", duty.Id));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }
        public UpdateResponse UpdateSign(Sign sign)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update sign set \"firstname\"=@Firstname,\"lastname\"=@Lastname,\"date\"=@Date,\"issigned\"=@IsSigned,\"iscompletlysigned\"=@IsCompletlySigned WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@Firstname", sign.FirstName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Lastname", sign.LastName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Date", sign.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsSigned", sign.IsSigned));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsCompletlySigned", sign.IsCompletlySigned));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", sign.Id));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error contractor data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "contractor data has been added successfully.");
            }
        }

        public UpdateResponse UpdateFile(File file)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update file set \"filename\"=@FileName,\"comment\"=@Comment, \"isfinal\"=@IsFinal WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@FileName", file.FileName));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", file.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@IsFinal", file.IsFinal));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", file.FileId));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some error File data cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "File data has been added successfully.");
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeleteResponse DeleteDepartment(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM department WHERE \"departmenttypeid\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "department cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(false, "department is deleted successfully!");
        }
        public DeleteResponse DeleteDepartments(List<int> idCollection)
        {
            bool isDeleted = false;

            foreach (var id in idCollection)
            {
                isDeleted = this.DeleteDepartment(id).IsExecuted;
            }

            if (isDeleted)
            {
                return new DeleteResponse(true, "Departments have been deleted!");
            }

            return new DeleteResponse(true, "Departments cant be deleted!");
        }
        public DeleteResponse DeleteLiabilityById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM liability WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "liability cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "liability is deleted successfully!");
        }
        public DeleteResponse DeleteClaimById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM claim WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "claim cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "claim is deleted successfully!");
        }
        public DeleteResponse DeleteDepartmentById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM department WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "department cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "department is deleted successfully!");
        }
        public DeleteResponse DeleteFineById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM fine WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "fine cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "fine is deleted successfully!");
        }
        public DeleteResponse DeleteCategoryById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM category WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "category cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "category is deleted successfully!");
        }
        public DeleteResponse DeleteDutyById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM duty WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "duty cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "duty is deleted successfully!");
        }
        public DeleteResponse DeleteNotificationById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM notification WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "notification cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "notification is deleted successfully!");
        }
        public DeleteResponse DeleteCommentById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM comment WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
<<<<<<< HEAD
                    cmd.Parameters.Add(new NpgsqlParameter("@ContractID", id));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int signId = Convert.ToInt32(reader[0].ToString());
                        string firstname = reader[1].ToString();
                        string lastname = reader[2].ToString();
                        DateTime date = Convert.ToDateTime(reader[3].ToString());
                        bool isSigned = Convert.ToBoolean(reader[4].ToString());
                        bool isCompletlySigned = Convert.ToBoolean(reader[5].ToString());
                        int contractId = Convert.ToInt32(reader[6].ToString());

                        signs.Add(new Sign(signId, date, firstname, lastname, isSigned, isCompletlySigned, contractId));
                    }
                    cmd.Dispose();

                    return new(true, "Comments are fetched successfully", signs);
                }
                catch (Exception ex)
                {
                    return new(false, "Comments cant be fetched.", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public ReadResponse<bool> IsContractActive(string userToken)
        {
            bool isActive = false;

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select id, status from contract where usertoken = @Usertoken AND status = @Status";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@UserToken", userToken));
                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "active"));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isActive = true;
                    }

                    cmd.Dispose();

                    if (isActive)
                    {
                        return new(true, "Contract is active", true);
                    }

                    return new(true, "Contract is already inactive", false);

                }
                catch (Exception ex)
                {
                    return new(false, "Comments cant be fetched.", false);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public ReadResponse<bool> IsContractActive(int id)
        {
            bool isActive = false;

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from contract where id = @Id AND status = @Status";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", id));
                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "active"));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isActive = true;
                    }

                    cmd.Dispose();

                    if (isActive)
                    {
                        return new(true, "Contract is active", true);
                    }

                    return new(true, "Contract is already inactive", false);

                }
                catch (Exception ex)
                {
                    return new(false, "Comments cant be fetched.", false);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public UpdateResponse UpdateContractStatus(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update contract set \"status\"=@Status WHERE \"id\"=@Id;";

                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "inactive"));
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", id));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new UpdateResponse(false, "Due to some reason status cant be changed.");
                }
                finally
                {
                    connection.Close();
                }

                return new UpdateResponse(true, "status has been changed successfully.");
            }
        }

        public UpdateResponse UpdateContractStatus(string userToken)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update contract set \"status\"=@Status WHERE \"usertoken\"=@UserToken;";

                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "inactive"));
                    cmd.Parameters.Add(new NpgsqlParameter("@UserToken", userToken));

=======
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
>>>>>>> 5158f050e533d041659a420ba6f682bdf10fea7f
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "comment cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "comment is deleted successfully!");
        }
        public DeleteResponse DeleteSignById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM sign WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "sign cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "sign is deleted successfully!");
        }
        public DeleteResponse DeleteFileById(int id)
        {
            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM file WHERE \"id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return new DeleteResponse(false, "file cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return new DeleteResponse(true, "file is deleted successfully!");
        }

        public ReadResponse<List<int>> ReadAllId()
        {
            var activeIds = new List<int>();
                    

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from contract where status = @Status";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@Status", "active"));
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader[0].ToString());

                        activeIds.Add(id);
                    }
                    cmd.Dispose();

                    return new(true, "Active IDs are fetched successfully", activeIds);
                }
                catch (Exception ex)
                {
                    return new(false, "Error", null);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public ReadResponse<List<Contract>> ReadAllContract()
        {
            var contracts = new List<Contract>();


            string query = "Select " +
                "                       c.id, " +
                "                       ct.type, " +
                "                       co.companyname, " +
                "                       co.person, " +
                "                       cs.status" +
                "          from contract c" +
                "                   join  info i on i.contractid = c.id" +
                "                   join contracttype ct on ct.id = i.contracttypeid" +
                "                   join contractor co on co.contractid = c.id" +
                "                   join contractstatus cs on cs.id = i.contractstatusid";
               

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = $"{query}";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        var contractType = reader[1].ToString();
                        var companyName = reader[2].ToString();
                        var person = reader[3].ToString();
                        var status = reader[4].ToString();

                        var contract = new Contract(id, status, null, companyName, person, null);

                        contracts.Add(contract);
                    }
                    cmd.Dispose();

                    return new(true, "Contracts have been fetched successfully", contracts);
                }
                catch (Exception ex)
                {
                    return new(false, "Error", null);
                }
                finally
                {
                    connection.Close();
                }
            }

            throw new NotImplementedException();
        }


        public ReadResponse<List<Contract>> ReadLike(string text)
        {
            var contracts = new List<Contract>();

            string queryText = $"'%{text}%'";

            string query = "Select " +
                "                       c.id, " +
                "                       ct.type, " +
                "                       co.companyname, " +
                "                       co.person, " +
                "                       cs.status" +
                "          from contract c" +
                "                   join  info i on i.contractid = c.id" +
                "                   join contracttype ct on ct.id = i.contracttypeid" +
                "                   join contractor co on co.contractid = c.id" +
                "                   join contractstatus cs on cs.id = i.contractstatusid" +
                "          where " +
               $"                   ct.type like {queryText} or" +
               $"                   co.companyname like {queryText} or" +
               $"                   co.person like {queryText} or" +
               $"                   cs.status like {queryText} or" +
               $"                   ct.type like {queryText}";

            using (IDbConnection connection = this.Connect)
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = $"{query}";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        var contractType = reader[1].ToString();
                        var companyName = reader[2].ToString();
                        var person = reader[3].ToString();
                        var status = reader[4].ToString();

                        var contract = new Contract(id, status, null, companyName, person, null);

                        contracts.Add(contract);
                    }
                    cmd.Dispose();

                    return new(true, "Contracts have been fetched successfully", contracts);
                }
                catch (Exception ex)
                {
                    return new(false, "Error", null);
                }
                finally
                {
                    connection.Close();
                }
            }

            throw new NotImplementedException();
        }
    }
}