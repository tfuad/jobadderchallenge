# Job Adder Challenge

This is a web application that finds the most suitable candidate for each job and presents it in a list view.


## Build / Development Steps

**Note: See TroubleShooter section at bottom if you encounter any issues**

### Prerequisite
* [Microsoft Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* ASP.NET and web development (Install via Visual Studio Installer)
* [Git](https://git-scm.com/downloads)
* [AngularJS](https://cli.angular.io/) (Used to create new components/services)
* [Node.js/NPM](https://phoenixnap.com/kb/install-node-js-npm-on-windows) (Needed to install AngularJs)

---
#### Optional tools
Not required but I personally use
[Git Extensions](http://gitextensions.github.io/)
to preview, stage and commit code.


Take a local copy of the project using the following command
```
git clone https://github.com/tfuad/jobadderchallenge.git
```
You can obtain this URL by clicking the "Code" button at the top of the page.

**Navigate** to the ClientApp directory and in the command prompt run the following commands
npm update

ng build

**Open** JobAdderChallenge.sln

Right click on **JobAdderChallenge** and select "**Manage NuGet Packages**" you should be given an option to install the packages.

If that fails you can navigate to **Tools -> NuGet Package Manager -> Package Manager Console**
Once that loads you can type **dotnet restore** and press enter which should start the installation process.

3. The project should be ready to **run** at this point can simply hit **F5** to build and run.

To ensure angular scss/typescript files are compiled it's best to use the ng program to monitor the directory using the following in the **ClientApp** folder

**ng build --extract-css --watch**


#### To build a production release of your angular project you can use the following

**ng build --prod**

---

#### To create new Angular components / services
Navigate to the ClientApp directory with command prompt and run either of the following commands

Component: used for providing an isolated model which lets you specify html/css/ts for your new front end component
Service: used for providing data to components by calling out to relevant server-side api

The generated components/services will follow this naming convention that some call "kebab-case"
Please see the following names
- yourAngularNameHere
- YourAngularNameHere
- YOURANGULARNAMEHERE

These will all be changed to **your-angular-name-here**.


#### To create a new component
ng generate **component** your-component-name-here

the file extension for components will be **.component.[html/spec.ts/ts/scss]**

#### To create a new service
ng generate **service** your-service-name-here

the file extension for services will be **.service.[spec.ts/ts]


## Assumptions

* The initial task implied a 1-to-1 relationship between Jobs and Candidates however it's structured as a 1-to-many relationship, the top candidate is shown on the main listing however four additional candidates can be seen on the detailed view.
* Due to absence of any local storage and lack of pagination, the front end also lacks pagination.
* Initially was using MVC for routing, discovered angular has routing support and migrated to that.
* Duplicate skill tags are to be ignored and filtered out
* Irrelevant descriptors have been left in as I feel a more sophisticated approach would be suitable in determining if they are irrelevant or not and what may be suitable for this dataset may not apply to another, a few approaches in mind could be a keyword system that a user can manage, using natural language processing to filter out words, first thing I'd check is if a set exists anywhere of common words that aren't really applicable.
* I assumed it would be preferable to create new skill matcher algorithms and be able to swap them out so support has been added for that.

#### Flaws

* There is no login mechanism and nothing to change, it's assumed to be a read-only application.
* The code lacks adequate error handling including no defensive programming strategies
* By leaving in the irrelevant descriptors this may harm the final score of the candidate against a given job.
* The current matcher places a lot of priority on the top skill matching up the, a candidate that matches only the top skill will outperform someone who does not have the top skill but has every other skill.

## Improvements

#### Error handling
* Code lacks defensive programming strategies and adequate error handling in general.
* It's assumed the web API is always up and available.
* Angular api requests are assumed to work and have not been adequately tested in the various failure scenarios (connection lost/incorrect data).

#### Performance

* The front end lacks pagination for job listing, ideally the source API would have pagination or we would capture and store the data locally and provide pagination functionality throughout the application to reduce load.
* The current scoring system calculates a score of every candidate for each job O(n*k) which can be quite expensive.
* There is no caching of source API or local API, all jobs/candidates are fetched and processed for each request even for detailed job views (computing scores and storing results only on changes would be one significant optimization)
* There is no server-side rendering for angular resulting in a noticeable but brief delay when switching pages.

#### Testing
* The application could benefit from having more tests, currently we're only testing the scoring method 


## Skill Matcher - thoughts / reasons


After reading through the API I wanted to write a formula that would generate a weighted score that prioritized a candidates top skills with a sharp drop off which allows more suitable candidates to rise above them.

The idea of this particular matcher is that we use the index of the job skill as a metric for the strength.
Given the reciprocal of the index will give us a number that gets smaller as it increases, the number would decrease by smaller and smaller amounts on its approach to 0.

I wanted to change the rate of decline by halving every step and also deal with an index of 0 which would be infinite, so to do that I raise 2 to the power of the index which gives me my halving capability and handles the case of 0 since 2^0 is equal to 1.

Now this only takes place if the candidate has a relevant skill to the given job.
We compute this score for the candidate based on the skill location and same for the job
We then multiply the numbers to obtain the score for that skill

I'll run through an example of one job and two candidates


  ```js
    "jobId": 5,
    "name": "Hospital Sales Representative",
    "company": "Contrado",
    "skills": "sales, pharmaceutical, clinical"
  
    "candidateId": 1,
    "name": "Grace Jefferson",
    "skillTags": "xcode, sales, pharmaceutical, xcode, prescriptions, clinical"

    "candidateId": 2,
    "name": "Svetlana Diller",
    "skillTags": "kotlin, sales, pharmaceutical, spreadsheets, carpentry"
  ```


So we'll extract the indexes of the matched jobs for each candidate with the index format of [jobIndex,candidateIndex]

```
candidateId: 1
sales = [0,1] = 1
pharmaceutical = [1,2]
clinical = [2,5]

candidate: 2
sales = [0,1] = 0.5
pharmaceutical = [1,2] = 0.125
```

```
for candidate 1
sales = 1 / (2^0) * 1 / (2^1) = 0.5
pharmaceutical = 1 / (2^1) * 1 / (2^2) = 0.125
clinical = 1 / (2^2) * 1 / (2^5) = 0.0078125
total score: 0.6328125

for candidate 2
sales = 1 / (2^0) * 1 / (2^1) = 0.5
pharmaceutical = 1 / (2^1) * 1 / (2^2) = 0.125

total score: 0.625

candidate 1 has a higher score so will be preferred over candidate 2
clinical did have an impact on the final score but was not as significant as the higher scores
```

This approach can be flawed as it gives a lot of weight to the top skill which can be impossible to overcome from another candidate with every other skill except for that top one.


## Troubleshooting

```
Directory does not exist.
Parameter name: directoryVirtualPath

bundles.Add(new Bundle("~/bundles/Angular")
```

If you encounter the above, ensure you've executed **ng build** in the ClientApp directory

```
An unhandled exception occurred: Cannot find module '@angular-devkit/build-angular/package.json'
```

If you encounter the above, be sure to navigate to the ClientApp directory and execute **npm update** followed by **ng build**

for continuous building use **ng build --extract-css --watch**

