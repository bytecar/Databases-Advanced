﻿namespace TeamBuilder.App.Core
{
    using Commands;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = Regex.Split(input.Trim(), @"\s+");
            //string[] args = input.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName)
            {
                case "RegisterUser":
                    RegisterCommand register = new RegisterCommand();
                    result = register.Execute(inputArgs);
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(inputArgs);
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute(inputArgs);
                    break;
                case "DeleteUser":
                    DeleteUserCommand deleteUser = new DeleteUserCommand();
                    result = deleteUser.Execute(inputArgs);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    result = exit.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}