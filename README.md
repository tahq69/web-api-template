# CRIP samples

This project is just a sample of 'perfect' web api application by my opinion.

### Project consist of:
 - Castle.Windsor: dependency injection;
 - Microsoft test framework: unit tests;
 - Entity Framework: database ORM;
 - VueJs: javascript front-end library;

### How to use:
 - Add this project as new remote for your repisitory;
 - Update `.\scripts\settings.ps1` file `Target` section with your project details;
 - Run `powershell .\scripts\rename.ps1` to update project name and namespaces;
 - Fix namespace order ocurrances in code;
 - Start .Web application;

### TODO list
 - Front end application suing SASS/TypeScript
   - Generate interfaces from C# models (http://type.litesolutions.net/Tutorials)
   - Use some bundler to compile in to single javascript file
