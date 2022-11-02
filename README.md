# T-Lab

Build a web application CRUD operation using .NET Core for Web-API &amp; Angular framework Web-UI. It has included some
special features like File-upload and download. Files have some specific type, that may allow uploading to the host. Angular
reactive form used to validate inputs. Here use SQL Lite for a relational database, this project will be cross-platform and have no database dependency, using code first approach for database management. 

**stack reference:**

- Asp.Net core `6`
- Angular `14`
- Angular Material `14`
- Bootstrap `5`
- Node version `16.18.0`
- SQL Lite

# Project startup instruction
clone this project and run below command in root directory of project. <br/>
SSH `git clone git@github.com:bdshanto/T-Lab.git` <br/>
HTTPS `git clone https://github.com/bdshanto/T-Lab.git`

**How to run backend**

1. In repository go to this directory `~/src/T-Lab/Web-API`
2. open visual studio with `TLabApp.sln`
3. set startup project `TLabApp.WebApi`
4. open Package Manager Console and select default porject `TLabApp.Infrastructure`
5. run this command `update-database`
6. run the project and remiemebr the `https://localhost:yourport`.

**How to run Front-End**

1. In repository go to this directory `~/src/T-Lab/Web-Console`
2. Open editor go to `src/environments/environment.ts`
3. update your port `baseUrl: 'https://localhost:yourport/api/'`
4. Install latest node and angular
5. now use `npm start`

# Author

Md. Hasibul Islam Shanto <br/>
Software Engineer


