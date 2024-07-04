namespace Client.Models;

public enum ApiType
{
    GET,
    POST,
    PUT,
    PATCH,
    DELETE
}


public enum State 
{ 
    Pending = 0,
    Show = 1,
    Hide = 2
}

public enum Status 
{ 
    Active = 0,
    Inactive = 1,
    Deleted = 2
}

public enum Ban { NotBanned = 0, Banned = 1 }
public enum CommentType { Comment = 0, Reply = 1 }
