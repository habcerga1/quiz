Registration

Registration controller 

Registration controller  ---> Post(RegistrationDto)                                           
    |                         IUserService.AddUserAsync(RegistrationDto) ---> 
    |
IUserService[UserService]