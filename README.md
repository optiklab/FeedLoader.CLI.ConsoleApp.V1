# VoxSmart console app

# Goals

To solve EXERCISE 1.

# EXERCISE 1

Required output:
1. Solution implementation for the coding exercise
2. Document of doubts/questions and assumptions

Exercise
	Write a piece of code to extract financial entity names from the feed https://feeds.a.dj.com/rss/RSSMarketsMain.xml

Goals
- We’re looking for a simple solution of the quality you’d expect to deliver as a solution.
- There’s no need for a user interface, there should be enough testing to see that this works.
- We’re not expecting you to take more than 90 minutes to complete the task in a programming language of your choice.
- Have fun!

# Assumptions:
While exact URL was given to me, I assume future improvements and extensions of this method/classes, thus I had to apply several best practices:
1. Implement general logic of downloading and parsing in separate assembly (Common) to be shared among its "users"
2. Every class is following SRP principle
3. Implement 3rd-party specifics in separate assembly (Providers), assuming that we might have MORE data providers with different API logic, endpoint URL's, formats (XML, JSON, BSON, etc.) etc.
4. Use Interfaces and Dependency Injection to better apply Unit and Integration tests (allow us to mock dependencies and write more focused tests)

Room for improvement:
- There are still room for improvement in separating Mapping logic between 3rd-party and our Entity Domain. I didn't do it due to time limits.
- Some tests (Console Output Handlers and Feed Integration Manager tests) are Integration tests, not Unit tests.
  This is bad, due to external dependencies on service availability and speed of execution. There are number of ways how to solve it, but it really depends on the actual goal.
  So I leave it like this for now.
- The output of this application is just a number of fin entities found and a list of its Titles. I didn't do much formatting or showing "Everything" because I do not know the actual purpose of this data.

# Prerequisites

To build the solution you need to have .NET Core 7.0 SDK installed.

To open and review the source code it's best to have:
- Visual Studio 2022
- .NET Core 7.0

# Build on Windows

>dotnet build
>dotnet run

The application will show you a general help how to use it and list the available commands (see below in this instruction).

# How to run

It is implemented as a CLI (Command Line Interface) and uses Console as a the main output driver.

Usage:
  VoxSmart.App [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  --read-url-feed <url>     Reads financial entity names from the feed XML available via specified URL.
  
# Examples of usage

>VoxSmart.App --help
Description:
  VoxSmart app to read the Financial feed.

>VoxSmart.App --version
1.0.0

>VoxSmart.App --read-url-feed https://feeds.a.dj.com/rss/RSSMarketsMain.xml

Example of output:
Extracted 20 entities:
0 Goldman Sachs Finalizes Deal to Offload Specialty Lender at Steep Loss
1 Birkenstock Shares Fall in Stock-Market Debut
2 A Gilded Age Is Fading for Luxury Brands
3 China's Country Garden Wilts
4 The Trial of Crypto's Golden Boy
5 High UAW Wages Shrink Detroit's Room to Maneuver
6 Profits Are Making a Comeback
7 Crypto Is Still Wild West Almost Year After FTX Collapse
8 Muni Funds That Use Borrowed Money Take a Big Hit
9 Downsizing Your Home Isn't the Money Move It Used to Be
10 Caroline Ellison Says Bankman-Fried Steered FTX Deception
11 What's Happening at the Sam Bankman-Fried Trial
12 How High Yields Brought Stocks Down, in 8 Charts
13 Birkenstock Prices IPO at $46 a Share
14 EV Buyers Can Get Instant $7,500 Tax Credit Starting in 2024
15 Stocks Rise for Third Straight Day
16 Hamas Militants Behind Israel Attack Raised Millions in Crypto
17 PepsiCo Serves Up Lukewarm Reassurance on Consumers
18 Healthcare Strikes Threaten to Prolong Wage Pressure on Hospitals
19 These Stocks Are Screaming Recession. It's Almost Time to Buy Them.

# External dependencies

## For running app

- .NET Core 7.0
- System.CommandLine (it is still in beta, but it exists for a long time and allow to easily build Command Line tools)

## For running tests using Visual Studio

dotnet add package FluentAssertions
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package Moq
dotnet add package xunit
dotnet add package xunit.runner.visualstudio

# Author

Anton Yarkov (C) 2023
anton.yarkov@gmail.com
+34 662 798 010
https://optiklab.github.io/