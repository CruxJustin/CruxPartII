using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LotBanking2.Crux
{
    public class CruxDB
    {
        //Database connection constants
        private string dataSource = "";
        private string initialCatalog = "";
        private string databaseUser = "";
        private string databasePassword = "";

        private SqlConnection databaseConnection;
        
        public CruxDB()
        {
            databaseConnection = new SqlConnection(dataSource  + initialCatalog + databaseUser + databasePassword);
        }

        public int insertLogin(String login, String password, int user_class_id, int option_mask)
        {
            SqlCommand insertNewLogin = new SqlCommand("INSERT INTO Login " +
                                                              "(login,  password,  user_class_id, option_mask)" +
                                                       "VALUES(@login, @password, @userClassId,  @optionMask)",
                                                       databaseConnection);
            insertNewLogin.Parameters.Add("@login", SqlDbType.VarChar, 30).Value = login;
            insertNewLogin.Parameters.Add("@password", SqlDbType.VarChar, 30).Value = password;
            insertNewLogin.Parameters.Add("@userClassId", SqlDbType.Int).Value = user_class_id;
            insertNewLogin.Parameters.Add("@optionMask", SqlDbType.Int).Value = option_mask;

            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = insertNewLogin.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public int login(String login, String password)
        {
            
            
            
            SqlCommand getLoginData = new SqlCommand("SELECT id " +
                                                       "FROM Login " +
                                                      "WHERE login = '@login'," +
                                                        "AND password = '@password'", databaseConnection);
            getLoginData.Parameters.Add("@login", SqlDbType.VarChar, 30).Value = login;
            getLoginData.Parameters.Add("@password", SqlDbType.VarChar, 30).Value = password;
            databaseConnection.Open();
            int id = -1;
            SqlDataReader reader;
            try
            {
                reader = getLoginData.ExecuteReader(CommandBehavior.SequentialAccess);
                while(reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            if (id >= 0)
            {
                return id;
            }
            return -2;
        }

        public int getUserClassId(int loginId)
        {

            SqlCommand getLoginData = new SqlCommand("SELECT user_class_id " +
                                                       "FROM Login " +
                                                      "WHERE id = @id",
                                                      databaseConnection);
            getLoginData.Parameters.Add("@login", SqlDbType.Int).Value = loginId;

            databaseConnection.Open();
            int id = -1;
            SqlDataReader reader;
            try
            {
                reader = getLoginData.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            if (id >= 0)
            {
                return id;
            }
            return -2;
        }

        public int insertBuilder(int builder_id, String name)
        {
            SqlCommand insertNewBuilder = new SqlCommand("INSERT INTO Builder_Data " +
                                                                   "( builder_id, name ) " +
                                                             "VALUES( @builderId, @name)",
                                                             databaseConnection);
            insertNewBuilder.Parameters.Add("@builderId", SqlDbType.Int).Value = builder_id;
            insertNewBuilder.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = name;
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = insertNewBuilder.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public String getBuilderName(int id)
        {
            SqlCommand getBuildersName = new SqlCommand("SELECT name" +
                                                          "FROM Builder_Data" +
                                                         "WHERE id = @id",
                                                         databaseConnection);
            getBuildersName.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataReader reader;
            String name = "";
            try
            {
                reader = getBuildersName.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            reader.Close();
            databaseConnection.Close();
            return name;
        }

        public int insertBuilderDocument(int builderId, String docName, byte[] doc)
        {
            SqlCommand insertNewBuilderDocument = new SqlCommand("INSERT INTO Builder_Documents" +
                                                                           "( builder_id, document_name, document)" +
                                                                     "VALUES( @builderId, @documentName, @document)",
                                                                     databaseConnection);

            insertNewBuilderDocument.Parameters.Add("@builderId", SqlDbType.Int).Value = builderId;
            insertNewBuilderDocument.Parameters.Add("@documentName", SqlDbType.VarChar, 30);
            insertNewBuilderDocument.Parameters.Add("@document", SqlDbType.Binary, doc.Length);

            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = insertNewBuilderDocument.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public BuilderDocumentData[] getBuilderDocumentData(int builder_id)
        {
            SqlCommand selectBuilderDocumentData = new SqlCommand("SELECT id, builder_id, document_name, file_name, last_modified, last_requested " +
                                                                 "FROM Builder_Documents " +
                                                                "WHERE buider_id = @builderId",
                                                                databaseConnection);
            selectBuilderDocumentData.Parameters.Add("@builderId", SqlDbType.Int).Value = builder_id;

            List<BuilderDocumentData> doclist = new List<BuilderDocumentData>();
            BuilderDocumentData[] docs = new BuilderDocumentData[0];
            int docCount = 0;
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = selectBuilderDocumentData.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    int bid = reader.GetInt32(1);
                    String dn = reader.GetString(2);
                    String fn = reader.GetString(3);
                    DateTime lm = reader.GetSqlDateTime(4).Value;
                    DateTime lr = reader.GetSqlDateTime(5).Value;
                    docCount++;
                    BuilderDocumentData newDoc = new BuilderDocumentData(i, bid, dn, fn, lm, lr);
                    doclist.Add(newDoc);
                }
                docs = new BuilderDocumentData[docCount];
                List<BuilderDocumentData>.Enumerator docEnum =  doclist.GetEnumerator();
                for(int i = 0; i < docCount; i++)
                {
                    docs[i] = docEnum.Current;
                    docEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return docs;
        }

        public byte[] getDocument(int id)
        {
            byte[] doc = new byte[0];

            SqlCommand selectBuilderDocument = new SqlCommand("SELECT document " +
                                                     "FROM Builder_Documents " +
                                                    "WHERE id = @id",
                                                    databaseConnection);
            selectBuilderDocument.Parameters.Add("@id", SqlDbType.Int);
            
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = selectBuilderDocument.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    Stream stream = reader.GetStream(0);
                    BinaryReader streamReader = new BinaryReader(stream);
                    doc = streamReader.ReadBytes((int)stream.Length);
                    streamReader.Close();
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return doc;
        }

        public int insertPoject(int builder_id, String project_name, float latitude, float longitude, Decimal aquisition_price, Decimal improvement_cost, Decimal estimated_sale_value)
        {
            SqlCommand insertNewProject = new SqlCommand("INSERT INTO Project" +
                                                                   "( builder_id, project_name, latitude,   longitude, aquisition_price, improvement_cost, estimated_sale_value)" +
                                                             "VALUES( @builderId, @projectName, @latitude, @longitude, @aquisitionPrice, @improvementCost, @estimatedSaleValue )",
                                                             databaseConnection);
            insertNewProject.Parameters.Add("@builderId", SqlDbType.Int).Value = builder_id;
            insertNewProject.Parameters.Add("@projectName", SqlDbType.Int).Value = project_name;
            insertNewProject.Parameters.Add("@latitude", SqlDbType.Float).Value = latitude;
            insertNewProject.Parameters.Add("@longitude", SqlDbType.Float).Value = longitude;
            insertNewProject.Parameters.Add("@aqusitoinPrice", SqlDbType.Decimal).Value = aquisition_price;
            insertNewProject.Parameters.Add("@improvementCost", SqlDbType.Decimal).Value = improvement_cost;
            insertNewProject.Parameters.Add("@estimatedSaleValue", SqlDbType.Decimal).Value = estimated_sale_value;

            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = insertNewProject.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public Project[] getProjects(int builder_id)
        {

            SqlCommand selectBuilderProjects = new SqlCommand("SELECT id, project_name, latitude, longitude, aquisition_price, improvement_cost, estimated_sale_value, last_modified" +
                                                                 "FROM Projects " +
                                                                "WHERE buider_id = @builderId",
                                                                databaseConnection);
            selectBuilderProjects.Parameters.Add("@builderId", SqlDbType.Int).Value = builder_id;

            List<Project> projectList = new List<Project>();
            Project[] projects = new Project[0];
            int projectCount = 0;
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = selectBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    String pn = reader.GetString(1);
                    float lat = reader.GetFloat(2);
                    float lon = reader.GetFloat(3);
                    Decimal aq = reader.GetDecimal(4);
                    Decimal ic = reader.GetDecimal(5);
                    Decimal esv = reader.GetDecimal(6);
                    DateTime lm = reader.GetSqlDateTime(7).Value;
                    projectCount++;
                    Project newProject = new Project(i, builder_id, pn, lat, lon, aq, ic, esv, lm);
                    projectList.Add(newProject);
                }
                projects = new Project[projectCount];
                List<Project>.Enumerator projectEnum = projectList.GetEnumerator();
                for (int i = 0; i < projectCount; i++)
                {
                    projects[i] = projectEnum.Current;
                    projectEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return projects;
        }

        public int insertLotType(int project_id, int lot_width, int lot_length, int count, Double purchase_price, Decimal release_price, Decimal sale_price)
        {
            SqlCommand insertNewLotType = new SqlCommand("INSERT INTO Lot_Types" +
                                                                   "( project_id, lot_width, lot_length,  count, purchase_price, release_price, sale_price)" +
                                                             "VALUES( @projectId, @lotWidth, @lotLength, @count, @purchasePrice, @releasePrice, @salePrice)",
                                                             databaseConnection);
            insertNewLotType.Parameters.Add("@projectId", SqlDbType.Int).Value = project_id;
            insertNewLotType.Parameters.Add("@lotWidth", SqlDbType.Int).Value = lot_width;
            insertNewLotType.Parameters.Add("@lotLenght", SqlDbType.Int).Value = lot_length;
            insertNewLotType.Parameters.Add("@count", SqlDbType.Int).Value = count;
            insertNewLotType.Parameters.Add("@purchasePrice", SqlDbType.Decimal).Value = purchase_price;
            insertNewLotType.Parameters.Add("@releasePrice", SqlDbType.Decimal).Value = release_price;
            insertNewLotType.Parameters.Add("@salePrice", SqlDbType.Decimal).Value = sale_price;
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = insertNewLotType.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public LotType[] getLotTypes(int project_id)
        {
            SqlCommand selectLotTypes = new SqlCommand("SELECT id, lot_width, lot_length, lot_count, purchase_count, sold_count, purchase_price, release_price, sale_price" +
                                                                 "FROM Projects " +
                                                                "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectLotTypes.Parameters.Add("@projectId", SqlDbType.Int).Value = project_id;

            List<LotType> lotTypeList = new List<LotType>();
            LotType[] lotTypes = new LotType[0];
            int lotTypeCount = 0;
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = selectLotTypes.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    int lw = reader.GetInt32(1);
                    int ll = reader.GetInt32(2);
                    int c = reader.GetInt32(3);
                    int pc = reader.GetInt32(4);
                    int sc = reader.GetInt32(5);
                    Decimal pp = reader.GetDecimal(6);
                    Decimal rp = reader.GetDecimal(7);
                    Decimal sp = reader.GetDecimal(8);
                    lotTypeCount++;
                    LotType newProject = new LotType(i, project_id, lw, ll, c, pc, sc, pp, rp, sp);
                    lotTypeList.Add(newProject);
                }
                lotTypes = new LotType[lotTypeCount];
                List<LotType>.Enumerator lotTypeEnum = lotTypeList.GetEnumerator();
                for (int i = 0; i < lotTypeCount; i++)
                {
                    lotTypes[i] = lotTypeEnum.Current;
                    lotTypeEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return lotTypes;
        }

        public int insertProjectSchedule(int project_id, int projected_lots_purchased, Decimal projected_value_purchased, DateTime schedule_date)
        {

            SqlCommand insertNewProjectSchedule = new SqlCommand("INSERT INTO Project_Schedule" +
                                                                           "( project_id, projected_lots_purchased, projected_value_purchased, schedule_date)" +
                                                                     "VALUES( @projectId, @projectedLotsPurchased,  @projectedValuePurchased,  @scheduleDate)",
                                                                 databaseConnection);
            insertNewProjectSchedule.Parameters.Add("@projectId", SqlDbType.Int).Value = project_id;
            insertNewProjectSchedule.Parameters.Add("@projectedLotsPurchased", SqlDbType.Int).Value = projected_lots_purchased;
            insertNewProjectSchedule.Parameters.Add("@projectedValuePurchased", SqlDbType.Decimal).Value = projected_value_purchased;
            insertNewProjectSchedule.Parameters.Add("@scheduleDate", SqlDbType.DateTime).Value = schedule_date;

            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = insertNewProjectSchedule.ExecuteReader(CommandBehavior.SequentialAccess);
            }
            catch (Exception e)
            {
                return -1;
            }
            reader.Close();
            databaseConnection.Close();
            return 1;
        }

        public ProjectSchedule[] getProjectSchedule(int project_id)
        {
            SqlCommand selectBuilderProjects = new SqlCommand("SELECT id, project_id, projected_lots_purchased, actual_lots_purchased, lots_sold," +
                                                                     "projected_value_purchased, actual_value_purchased, value_sold, projected_draw," +
                                                                     "actual_draw, schedule_date, date_created, last_modified" +
                                                                 "FROM Project_Schedule " +
                                                                "WHERE project_id = @projectId",
                                                                databaseConnection);
            selectBuilderProjects.Parameters.Add("@projectId", SqlDbType.Int).Value = project_id;

            List<ProjectSchedule> projectScheduleList = new List<ProjectSchedule>();
            ProjectSchedule[] projectSchedule = new ProjectSchedule[0];
            int projectScheduleCount = 0;
            databaseConnection.Open();

            SqlDataReader reader;
            try
            {
                reader = selectBuilderProjects.ExecuteReader(CommandBehavior.SequentialAccess);
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    int plp = reader.GetInt32(1);
                    int alp = reader.GetInt32(2);
                    int ls = reader.GetInt32(3);
                    Decimal pvp = reader.GetDecimal(4);
                    Decimal avp = reader.GetDecimal(5);
                    Decimal pvs = reader.GetDecimal(6);
                    Decimal avs = reader.GetDecimal(7);
                    Decimal pd = reader.GetDecimal(8);
                    Decimal ad = reader.GetDecimal(9);
                    DateTime sd = reader.GetSqlDateTime(10).Value;
                    DateTime dc = reader.GetSqlDateTime(11).Value;
                    DateTime lm = reader.GetSqlDateTime(12).Value;
                    projectScheduleCount++;
                    ProjectSchedule newProjectSchedule = new ProjectSchedule(i, project_id, pn, lat, lon, aq, ic, esv, lm);
                    projectScheduleList.Add(newProjectSchedule);
                }
                projectSchedule = new ProjectSchedule[projectScheduleCount];
                List<ProjectSchedule>.Enumerator projectScheduleEnum = projectScheduleList.GetEnumerator();
                for (int i = 0; i < projectScheduleCount; i++)
                {
                    projectSchedule[i] = projectScheduleEnum.Current;
                    projectScheduleEnum.MoveNext();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            reader.Close();
            databaseConnection.Close();

            return projectSchedule;
        }
    }

    public class BuilderDocumentData
    {
        private int id;
        private int builderId;
        private String docName;
        private String fileName;
        private DateTime last_modified;
        private DateTime last_requested;
        public BuilderDocumentData(int i, int bid, String dn, String fn, DateTime lm, DateTime lr)
        {
            id = i;
            builderId = bid;
            docName = dn;
            fileName = fn;
            last_modified = lm;
            last_requested = lr;
        }
        public int getBuilderId()
        {
            return builderId;
        }
        public String getDocumentName()
        {
            return docName;
        }
        public String getFileName()
        {
            return fileName;
        }
        public DateTime getLastModifiedTime()
        {
            return last_modified;
        }
        public DateTime getLastRequestedTime()
        {
            return last_requested;
        }
        public Boolean isUpToDate()
        {
            return DateTime.Compare(last_modified, last_requested) >= 0;
        }
    }

    public class Project
    {
        private int id;
        private int builderId;
        private String projectName;
        private float latitude;
        private float longitude;
        private Decimal aquisitionPrice;
        private Decimal improvementCost;
        private Decimal estimatedSaleValue;
        private DateTime lastModified;

        public Project(int i, int bid, String pn, float lat, float lon, Decimal aq, Decimal ic, Decimal esv, DateTime lm)
        {
            id = i;
            builderId = bid;
            projectName = pn;
            latitude = lat;
            longitude = lon;
            aquisitionPrice = aq;
            improvementCost = ic;
            estimatedSaleValue = esv;
            lastModified = lm;
        }

        public int getId()
        {
            return id;
        }

        public int getBuilderId()
        {
            return builderId;
        }

        public string getProjectName()
        {
            return projectName;
        }

        public Coordinates getCoordinates()
        {
            return new Coordinates(latitude, longitude);
        }

        public Decimal getAquisitionPrice()
        {
            return aquisitionPrice;
        }

        public Decimal getImprovementCost()
        {
            return improvementCost;
        }

        public Decimal getEstimatedSaleValue()
        {
            return estimatedSaleValue;
        }

        public DateTime getLastModified()
        {
            return lastModified;
        }
    }

    public class Coordinates
    {
        public float latitude;
        public float longitude;
        public Coordinates(float lat, float lon)
        {
            latitude = lat;
            longitude = lon;
        }
    }

    public class ProjectSchedule
    {
        private int id;
        private int projectId;
        private int projectedLotsPurchased;
        private int actualLotsPurchased;
        private int lotsSold;
        private Decimal projectedValuePurchased;
        private Decimal actualValuePurchased;
        private Decimal projectedValueSold;
        private Decimal actualValueSold;
        private Decimal projectedDraw;
        private Decimal actualDraw;
        private DateTime scheduelDate;
        private DateTime dateCreated;
        private DateTime lastModified;

        public ProjectSchedule(int i, int pid, int plp, int alp, int ls, Decimal pvp, Decimal avp,
            Decimal pvs, Decimal avs, Decimal pd, Decimal ad, DateTime sd, DateTime dc, DateTime lm)
        {
            id = i;
            projectId = pid;
            projectedLotsPurchased = plp;
            actualLotsPurchased = alp;
            lotsSold = ls;
            projectedValuePurchased = pvp;
            actualValuePurchased = avp;
            projectedValueSold = pvs;
            actualValueSold = avs;
            projectedDraw = pd;
            actualDraw = ad;
            scheduelDate = sd;
            dateCreated = dc;
            lastModified = lm;
        }

        public int getId()
        {
            return id;
        }
        public int getProjectId()
        {
            return projectId;
        }
        public int getProjectedLotsPurchased()
        {
            return projectedLotsPurchased;
        }
        public int getActualLotsPurchased()
        {
            return actualLotsPurchased;
        }
        public int getLotsSold()
        {
            return lotsSold;
        }
        public Decimal getProjectedValuePurchased()
        {
            return projectedValuePurchased;
        }
        public Decimal getActualValuePurchased()
        {
            return actualValueSold;
        }
        public Decimal getValueSold()
        {
            return projectedValueSold;
        }
        public Decimal getProjectedDraw()
        {
            return projectedDraw;
        }
        public Decimal getActualDraw()
        {
            return actualDraw;
        }
        private DateTime getScheduelDate()
        {
            return scheduelDate;
        } 
    }

    public class LotType
    {
        private int id;
        private int projectId;
        private int lotWidth;
        private int lotLength;
        private int lotTypeCount;
        private int purchasedCount;
        private int soldCount;
        private Decimal purchasePrice;
        private Decimal releasePrice;
        private Decimal salePrice;

        public LotType(int i, int pid, int lw, int ll, int c, int pc, int sc, Decimal pp, Decimal rp, Decimal sp)
        {
            id = i;
            projectId = pid;
            lotWidth = lw;
            lotLength = ll;
            lotTypeCount = c;
            purchasedCount = pc;
            soldCount = sc;
            purchasePrice = pp;
            releasePrice = rp;
            salePrice = sp;
        }

        public int getId()
        {
            return id;
        }
        public int getProjectId()
        {
            return projectId;
        }
        public lotDimensions getLotDimensions()
        {
            return new lotDimensions(lotWidth, lotLength);
        }
        public int getLotTypeCount()
        {
            return lotTypeCount;
        }
        public int getPurchasedCount()
        {
            return purchasedCount;
        }
        public int getSoldCount()
        {
            return soldCount;
        }
        public Decimal getPurchasePrice()
        {
            return purchasePrice;
        }
        public Decimal getReleasePrice()
        {
            return releasePrice;
        }
        public Decimal getSalePrice()
        {
            return salePrice;
        }
    }
    public class lotDimensions
    {
        public int width;
        public int length;
        public lotDimensions(int w, int l)
        {
            width = w;
            length = l;
        }
    }
}