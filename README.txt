# PencilKata

PencilKata is a solution to the Pencil Kata described at https://github.com/PillarTechnology/kata-pencil-durability
Pencil Kata is coded in C#

## Installation / Requirements

The solution is ready to run in visual studio when cloned from the repository. Navigate to and open the PencilKata.sln file.
To build and execute the tests thru Cake (C# Make) use Windows Powershell, navigate to the folder where the repository was cloned, and execute the 
'build.ps1' file. 

## Usage

Tests can be ran using the Visual Studio Test Explorer and selecting the tests to run.
To see text written, erased and edited on the ommand line using the various methods avaliable, open the program.cs file and create a new 
pencil using "Pencil pencil = new Pencil();" and create a paper for the pencil to write on using "Paper paper = new Paper(); 
Access the various methods the pencil has using "pencil." notation. The 39 tests serve as validation and proof of concept of 
the different functions this program can perform. 

## Contact

This repository was created by Nick Doran, who can be reached at chasedoran6@gmail.com