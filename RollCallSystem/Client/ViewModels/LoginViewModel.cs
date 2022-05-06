﻿using RollCallSystem.Client.Services;
using RollCallSystem.Shared;

namespace RollCallSystem.Client.ViewModels
{
    public class LoginViewModel
    {
        

        public LoginViewModel()
        {
            
        }

        public async Task LogIn(string email, string password)
        {
            LoginService loginService = new LoginService();
            bool sucess = await loginService.LoginUser(email, password);
        }

        public async Task GetCurrentLesson(User user)
        {
            LessonService lessonService = new LessonService();
            bool success = await lessonService.GetCurrentLesson(user);
        }
    }
}
