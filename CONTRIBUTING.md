## Developer Guidelines for ALSI.CaseConversions

This document provides guidelines for contributing to the ALSI.CaseConversions project, detailing performance requirements, code style, and contribution practices.

### Performance Requirements

The primary goal of ALSI.CaseConversions is to provide a fast and efficient way to convert strings into target cases. The current implementation has been benchmarked and optimized to outperform standard implementations such as `System.Text.Json`. If your implementation is slower, your pull request will be denied.

### Code Style and Formatting

ALSI.CaseConversions adheres to strict coding standards to maintain code quality and consistency across the project. We use the following tools:

- **StyleCop**: Ensures compliance with coding style rules, including naming conventions, documentation requirements, and code layout.
- **CSharpier**: An opinionated code formatter that enforces a consistent code style across the project. All code should be formatted with CSharpier before submission.

### Code Structure

- **Namespace**: All public and internal classes and methods are housed under the `ALSI.CaseConversions` namespace.
- **Core Design**:
  - Use the `Converter` class to convert strings into target cases, extending into case name-spaced static wrappers.
  - Use the `ICaseConverter` interface to define a custom converter.
  - Use static abstract methods or unsafe function pointers if you have to implement generic code execution.

### Contribution Guidelines

Contributions to ALSI.CaseConversions are welcome! Please follow these guidelines to ensure smooth collaboration:

#### 1. **Fork and Clone the Repository**

- Fork the repository on GitHub.
- Clone your fork locally:

     ```bash
     git clone https://github.com/your-username/ALSI.CaseConversions.git
     cd ALSI.CaseConversions
     ```

#### 2. **Build and Test the Project**

- Ensure that the project builds without errors.
- Run the unit tests to verify that everything works as expected:

     ```bash
     dotnet build
     dotnet test
     ```

#### 3. **Follow Coding Standards**

- Ensure your code follows the StyleCop rules. Violations will be flagged during the build process.
- Format your code with CSharpier before committing:

     ```bash
     dotnet csharpier .
     ```

#### 4. **Write Unit Tests**

- Any new features or bug fixes should be accompanied by unit tests that verify their correctness.
- Place tests in the appropriate `UnitTests` project within the `ALSI.CaseConversions.UnitTests` namespace.

#### 5. **Submit a Pull Request**

- Push your changes to your fork.
- Submit a pull request to the `dev` branch of the main repository.
- Provide a clear description of the changes, including the problem being solved or feature being added.

### Performance Considerations for Contributions

Given the focus on performance, any changes or new features should:

- **Be Benchmark Tested**: Include benchmark results that demonstrate the performance impact (positive or negative) of the changes.
- **Minimize Allocations**: Use stack allocation (`stackalloc`) and `Span<T>` where appropriate to keep heap allocations low.
- **Optimize Hot Paths**: Identify and optimize any hot paths in the code, leveraging inlining and other performance-enhancing techniques.
