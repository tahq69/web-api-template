# CRIP samples

This project is just a sample of 'perfect' web api application by my opinion.

### Project consist of:

- Castle.Windsor: dependency injection;
- Microsoft test framework: unit tests;
- Entity Framework: database ORM;
- VueJs: javascript front-end library;

### VS Extensions required:

- [NPM Task Runner](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.NPMTaskRunner)
- [Vue.js Pack](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.VuejsPack-18329)

### How to use:

- Add this project as new remote for your repisitory;
- Update `.\scripts\settings.ps1` file `Target` section with your project details;
- Run `powershell .\scripts\rename.ps1` to update project name and namespaces;
- Fix namespace order error ocurrances in code;
- Run for development:
  - Start .Web application on IIS / IISExpress;
  - Configure .Web application `vue.config.js` devServer.proxy property to target API server url;
  - In NPM Task Runner start `serve` task (it will show URL to open in browser with hot reload support);
- Production build:
  - In NPM Task Runner start `build` task;
  - Publish .Web application to target IIS;


### TODO list

- Front end application suing SASS/TypeScript
  - Generate interfaces from C# models (http://type.litesolutions.net/Tutorials)
  - Use some bundler to compile in to single javascript file
