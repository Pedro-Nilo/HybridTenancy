db.createUser({
    user: "pedro",
    pwd: "Pedro@123",
    roles: [
        {
            role: "userAdminAnyDatabase",
            db: "admin"
        }
    ]
});
