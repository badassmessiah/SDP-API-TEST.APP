public class UserResponse
{
    public List<ResponseStatus> response_status { get; set; }
    public ListInfo list_info { get; set; }
    public List<User> users { get; set; }
}

public class ResponseStatus
{
    public int status_code { get; set; }
    public string status { get; set; }
}

public class ListInfo
{
    public bool has_more_rows { get; set; }
    public int start_index { get; set; }
    public int row_count { get; set; }
}

public class User
{
    public string email_id { get; set; }
    public string extension { get; set; }
    public bool? purchase_approver { get; set; }
    public Dictionary<string, object> ci_people_fields { get; set; }
    public string description { get; set; }
    public bool? is_vipuser { get; set; }
    public object reporting_to { get; set; }
    public string type { get; set; }
    public Citype citype { get; set; }
    public string cost_per_hour { get; set; }
    public CiDefaultFields ci_default_fields { get; set; }
    public bool? can_generate_authtoken { get; set; }
    public string org_user_status { get; set; }
    public string id { get; set; }
    public object department { get; set; }
    public string first_name { get; set; }
    public bool? service_request_approver { get; set; }
    public CreatedTime created_time { get; set; }
    public bool? is_technician { get; set; }
    public string jobtitle { get; set; }
    public string mobile { get; set; }
    public ProfilePic profile_pic { get; set; }
    public ProjectRoles project_roles { get; set; }
    public string last_name { get; set; }
    public string sms_mail_id { get; set; }
    public string middle_name { get; set; }
    public object created_by { get; set; }
    public string ciid { get; set; }
    public string purchase_approval_limit { get; set; }
    public string login_name { get; set; }
    public string phone { get; set; }
    public object sip_user { get; set; }
    public string employee_id { get; set; }
    public Domain domain { get; set; }
    public string name { get; set; }
    public UserUdfFields user_udf_fields { get; set; }
    public bool? enable_telephony { get; set; }
    public string status { get; set; }
}

public class Citype
{
    public string name { get; set; }
    public int id { get; set; }
}

public class CiDefaultFields
{
    public object udf_pickref_1 { get; set; }
}

public class CreatedTime
{
    public string display_value { get; set; }
    public string value { get; set; }
}

public class ProfilePic
{
    public string content_url { get; set; }
}

public class ProjectRoles
{
    public string name { get; set; }
    public string id { get; set; }
}

public class Domain
{
    public string canonical_name { get; set; }
    public string name { get; set; }
    public string id { get; set; }
}

public class UserUdfFields
{
    public object udf_pick_7513 { get; set; }
    public object udf_long_7514 { get; set; }
    public object udf_pick_7512 { get; set; }
    public object udf_sline_6601 { get; set; }
    public object udf_sline_1 { get; set; }
}
