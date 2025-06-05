# Creating a Robust C# Program with Copilot agent At GitHub

Follow the instructions on this readme to Create a C# Console App using GitHub Copilot Only from an application shell with GitHub Copilot using issues and pull request reviews.

## Using VSCode

If you would like to see a similar solution using VS Code [Check Out This Repo](...)  

## Prerequisites

Set up a repo at GitHub and clone it locally (establishes main branch upstream tracking).  Give it a Visual Studio .gitignore, a README.md and a license of choice. 

Do not add any code, but make sure that you have cloned the repo locally so that you can add code to it easily. 

>**Note**: It is likely you would have been able to start this entire project from scratch entirely using issues.  For simplicity, this demo sets a project shell in place so that the walkthrough can progress easily.  

## Instructions

Ensure that you have a local cloned repository before beginning.  Once that is in place, follow these instructions to let GitHub Copilot Agent work its magic on your repository.

1. Create a feature branch

    ```git
    git switch -c 1-initial-work-yourname
    ```  

    Your current repo should only have the following files

    |- .gitignore  
    |- LICENSE
    |- README.md  

1. Get the files

    Make sure to get the files. [Download the files from this link](....)

1. Add the code

    Extract the files: `./StarterFiles/CSharpCalculator.zip` and place them into your working directory. 
    
    These files will stub in the project shell.  
    
    >**Note:** Ensure that the code runs as expected from your local machine before pushing to GitHub.

    The Repo branch should look like this:

    |- CSharpCalculator  
    |    |- CSharpCalculator.csproj  
    |    |- ConfigurationBuilderSingleton.cs  
    |    |- Program.cs  
    |    |- appsettings.json  
    |    |- secrets_example.json  
    |- Operations.Tests  
    |    |- OperationsTests.csproj  
    |    |- TestValidation.cs  
    |- Operations  
    |    |- Operations.csproj  
    |    |- Validation.cs  
    |- .gitignore  
    |- CSharpCalculator.sln  
    |- LICENSE  
    |- README.md  

    >**Note** Because it is critical, I have included the `.gitignore` in the sample files. This will cause you to have to overwrite your original file on extraction/copy-paste.

    Once you have the starter code in place and it is working, push it to GitHub on your branch.  Once the code is in GitHub, open your browser to the repo to proceed.

    ```git
    git push -u origin 1-initial-work-yourname  
    ```  

1. Open a pull request at GitHub
    
    Open a pull request. Assign the copilot agent to review your code.  It shouldn't take too long.  
    
1. Wait a few minutes for `Copilot` to complete the review

    You should get a summary from the review.

    When you are done reviewing, merge your code.

1. Create an issue

    Open the github repo and add an issue.  Place the following markdown in the issue

    ```markdown
    As a user, I would like to be able to input two numbers and select an operation to complete.  The list of valid operations are:
    - Add
    - Subtract
    - Multiply
    - Divide
    - Remainder

    Before asking for numbers from the user, the program should present a menu with options for the operation. The valid operations are already defined above.  After selecting the operation, the program should gather the numbers from the user (the code for user input for the two numbers is already in place).

    Additionally, The program should run until the user states that they are done performing calculations.  Each new calculation should allow for the the user to input the two numbers for the calculation and confirm that the collected numbers are as intended (current code already allows for getting numbers, validating they successfully convert to double, and confirming).

    The user would also like the menu to be well formatted, with a title and options similar to this:

    **************************************
    Welcome To the CSharp Calculator
    **************************************
    * What would you like to do today? 
    ----------------------------------------
    1) Add
    2) Subtract
    3) Multiply
    4) Divide
    5) Remainder
    6) Quit
    **************************************

    Acceptance Criteria
    - [ ] AC 1.0 : Create a new Class called `Calculations` in the `Operations project
    - [ ] AC 1.1: Add each operation as a functional method that takes the two numbers and returns the result as expected
    - [ ] AC 2.0: Create a new Class called `TestCalculations` in the `Operations.Tests` project
    - [ ] AC 2.1: Thoroughly test multiple scenarios for each calculation using [Theory] and [Inline Data]
    - [ ] AC 2.2: Ensure that `Divide` and `Remainder` successfully throw an exception if the user attempts to `Divide By Zero`
    - [ ] AC 2.3: Ensure the Divide By Zero exceptions are tested in the `TestCalculations` class
    - [ ] AC 3.0: Add a functional loop to run multiple calculations in the Program.cs file
    - [ ] AC 3.1: Present a menu to the user that is well formatted.  Use `*` characters to create a border around the outside and for the Title of the menu, and use `-` characters to separate lines
    - [ ] AC 3.2: After getting the user input for their choice, Gather the two numbers to calculate
    - [ ] AC 3.3: Perform the calculation
    - [ ] AC 3.4: Output the result
    - [ ] AC 3.5: For the console output, when the output is from the system, print in the color Green, for the user input, set the color to yellow, and for the result output, use the color Cyan.
    ```  
    
    Create the issue.  

1. Assign the Copilot Agent to the issue

    >**Note:** this is a `very` large issue that should likely have been 3 or 4 issues.  One thing to consider is to make sure that each scope of work is self-contained and doesn't have a lot of dependencies, and can be completed in one pull request.

1. Wait for copilot to complete the issue

    Copilot will immediately open a pull request as a Work In Progress (WIP) pull request.

    You can watch the progress if you would like.  Drill into the `pull request` and look for the `View Session`.  It's pretty fascinating to see what the Github Copilot agent can do.

1. Once the agent work has completed, it will update the PR and request that you review/merge it

    Some interesting notes

    - It set the color to red on error message without being asked
    - For some reason, the program was downgraded to .NET 8 when I ran this (I don't know if I trust that will always happen, but I sure didn't ask for that).

1. Get the program locally and make sure it works

    Update your local repository:

    ```git
    git fetch && git pull --prune
    ```  

    Then get the branches

    ```git
    git branch -a
    ```  

    Find the name of the branch that github copilot created, i.e. `copilot/fix-2`

    Replace branchname in the command below to switch to the branch

    ```git
    git switch <branchname>
    ```  

    Navigate to the project folder (where the *.csproj file is)

    ```bash
    cd .\CSharpCalculator
    ```  

    Run the project:

    ```bash
    dotnet run
    ```

    Run some input, make sure it's good

1. Run the tests

    Navigate to the tests project folder (assuming you are in the CSharp project folder...)

    ```bash
    cd ..\Operations.Tests
    ```  

    run the tests

    ```bash
    dotnet test
    ```  

1. Once the code looks good, ask Copilot to fix something

    For me, all of the projects were `downgraded` to .net 8.  I want to ask Copilot to **NOT** do that.

    Copilot won't be able to execute .NET 9, so it will make statements about this fact.

    Navigate to the PR and start a review

    In the review, tag copilot and state

    ```text
    @copilot DO NOT downgrade to net8.0.  This should remain as net9.0
    ```  

    Or

    ```text
    @copilot Do NOT downgrade versions for these nuget packages
    ```  

    You will need to tag copilot on all of the project files that were downgraded as well as the package versions.

    Finish your review, but mark `Request changes`

    Copilot will now need to respond to your review, just like a human would.

1. Review the changes again

    From copilot:

    ```text
    The changes were minimal and surgical - I only modified the specific lines that @blgorman requested to be reverted, restoring them to their original state from the initial commit (6405c5b). The core functionality of the calculator application, including the menu system, mathematical operations, and comprehensive test suite, remains intact and unchanged.

    While the current sandboxed environment cannot build .NET 9.0 projects due to having only .NET SDK 8.0.116, this is expected since @blgorman specifically requested to maintain .NET 9.0 targeting, indicating their production environment has the appropriate .NET 9.0 SDK available.

    ```  

1. Merge the pull request.  The work is completed.

1. FYI, you could do this from your phone and not even need to be on a computer to get a full application developed...

