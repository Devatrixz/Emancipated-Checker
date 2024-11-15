# Emancipated Checker

## Overview
Emancipated Checker is a tool designed for users to utilize query systems effectively while adhering to legal and ethical guidelines. Below is a guide for developers interested in contributing to the project.

## How to Contribute
### 1. Fork the Repository
- Navigate to the Emancipated Checker GitHub repository.
- Click on the **Fork** button at the top right corner to create a copy of the repository in your GitHub account.

### 2. Clone the Repository
- Clone the forked repository to your local machine using the command:
  ```bash
  git clone https://github.com/devatrix/emancipated-checker.git
  ```
- Navigate into the project directory:
  ```bash
  cd emancipated-checker
  ```

### 3. Create a Branch
- Create a new branch for your feature or bug fix:
  ```bash
  git checkout -b feature/your-feature-name
  ```

### 4. Make Your Changes
- Implement your changes in the codebase.
- Ensure your code adheres to the project’s coding standards and best practices.

### 5. Run Tests
- Run any existing tests to ensure your changes do not break the application:
  ```bash
  dotnet test
  ```
- Add new tests if you are introducing new features.

### 6. Commit Your Changes
- Stage your changes:
  ```bash
  git add .
  ```
- Commit with a descriptive message:
  ```bash
  git commit -m "Add feature: description of your feature"
  ```

### 7. Push Your Branch
- Push your branch to your GitHub fork:
  ```bash
  git push origin feature/your-feature-name
  ```

### 8. Create a Pull Request
- Go to the original repository and click on **New Pull Request**.
- Select your branch and submit the pull request for review.
- Provide a detailed description of your changes.

## Installation from CD (For Testing Purposes)
1. Insert the Emancipated Checker CD into your computer.
2. When the autoplay window opens, click on "Open Application."
3. Follow the prompts to complete the installation.
4. After installation, launch the program.
5. Ensure your system meets the requirement of .NET Framework 4.7.1 or higher.

## Technical Details
### Required NuGet Packages
1. **TurkishCitizenID**
   - **Purpose**: Validates Turkish Republic Identification Numbers, integrating with government databases for verification.
   - **Usage**: Used for identity verification of Turkish citizens.
   - **Features**:
     - Algorithmic validation of ID numbers.
     - Compatibility with online databases.

2. **LibKimlik**
   - **Purpose**: Complements TurkishCitizenID for faster, local verification.
   - **Usage**: Employed in offline processes or when quick validation is needed.
   - **Features**:
     - Local data processing.
     - High-performance verification.

3. **WebView2**
   - **Purpose**: Integrates web-based content into the program using Microsoft’s WebView2 technology.
   - **Usage**: Displays web content such as online verification processes and help documents.
   - **Features**:
     - Built-in browser functionality.
     - Support for HTML, CSS, and JavaScript.

### System Requirements
#### Minimum Requirements:
- **RAM**: 1 GB
- **Storage**: 1.8 GB
- **Processor**: 2.0 GHz dual-core
- **.NET Framework**: 4.7.1 or higher
- **Screen Resolution**: 1366x768

#### Recommended Requirements:
- **RAM**: 4 GB or higher
- **Storage**: 5 GB of free disk space
- **Processor**: 3.0 GHz quad-core
- **Graphics**: DirectX 11-supported graphics card
- **Screen Resolution**: 1920x1080 or higher

## Command Line Tools
Emancipated Checker provides command-line tools for easier operation
