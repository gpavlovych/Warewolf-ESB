﻿@fileFeature
Feature: Create
	In order to be able to create files
	as a Warewolf user
	I want a tool that creates a file at a given location


Scenario Outline: Create file at location
	Given I have a destination path '<destination>' with value '<destinationLocation>'
	And overwrite is '<selected>'
	And destination credentials as '<username>' and '<password>'
	And use private public key for destination is '<destinationPrivateKeyFile>'
	And result as '<resultVar>'
	When the create file tool is executed
	Then the result variable '<resultVar>' will be '<result>'
	And the execution has "<errorOccured>" error
	And the debug inputs as
         | File or Folder                        | Overwrite  | Username   | Password | Destination Private Key File |
         | <destination> = <destinationLocation> | <selected> | <username> | String   | <destinationPrivateKeyFile>  |
	And the debug output as
		|                        |
		| <resultVar> = <result> |
	Examples: 
		| No | Name       | destination | destinationLocation                                            | selected | username                     | password | resultVar  | result  | errorOccured | destinationPrivateKeyFile |
		| 1  | Local      | [[path]]    | c:\myfile.txt                                                  | True     | ""                           | ""       | [[result]] | Success | NO           |                           |
		| 2  | UNC        | [[path]]    | \\\\RSAKLFSVRSBSPDC\FileSystemShareTestingSite\test.txt        | True     | ""                           | ""       | [[result]] | Success | NO           |                           |
		| 3  | UNC Secure | [[path]]    | \\\\RSAKLFSVRSBSPDC\FileSystemShareTestingSite\Secure\test.txt | True     | dev2.local\IntegrationTester | I73573r0 | [[result]] | Success | NO           |                           |
		| 4  | FTP        | [[path]]    | ftp://rsaklfsvrsbspdc:1001/FORTESTING/test.txt                 | True     | ""                           | ""       | [[result]] | Success | NO           |                           |
		| 5  | FTPS       | [[path]]    | ftp://rsaklfsvrsbspdc:1002/FORTESTING/test.txt                 | True     | IntegrationTester            | I73573r0 | [[result]] | Success | NO           |                           |
		| 6  | SFTP       | [[path]]    | sftp://localhost/test.txt                                      | True     | dev2                         | Q/ulw&]  | [[result]] | Success | NO           |                           |
		| 7  | SFTP       | [[path]]    | sftp://localhost/test1.txt                                     | True     | dev2                         | Q/ulw&]  | [[result]] | Success | NO           | C:\\Temp\\key.opk         |


Scenario Outline: Create file at location Nulls
	Given I have a destination path '<destination>' with value '<destinationLocation>'
	And overwrite is '<selected>'
	And destination credentials as '<username>' and '<password>'
	And use private public key for destination is '<destinationPrivateKeyFile>'
	And result as '<resultVar>'
	When the create file tool is executed
	Then the execution has "<errorOccured>" error

	Examples: 
		| No | Name       | destination | destinationLocation                                           | selected | username                      | password | resultVar  | result  | errorOccured | destinationPrivateKeyFile |
		| 1  | Local      | [[path]]    | NULL                                                          | True     |                               |          | [[result]] | Failure | AN           |                           |
#		| 2  | Local      | [[path]]    | v:\myfile.txt                                                 | True     |                               |          | [[result]] | Failure | AN           |                           |
#		| 3  | SFTP       | [[path]]    | sftp://localhost/test1.txt                                    | True     | ""                            | Q/ulw&]  | [[result]] | Failure | AN           | C:\\Temp\                 |
#		| 4  | UNC        | [[path]]    | \\\\RSAKLFSVRSBSPDC\FileSystemShareTestingSite\test.txt       | True     | ""                            | ""       | [[result]] | Failure | AN           |                           |
#		| 5  | UNC Secure | [[path]]    | \\\\RSAKLFSVRSBSPDC\FileSystemShareTestingSite\Secure\test.tx | True     | dev2.local\IntegrationTesteru | I73573r0 | [[result]] | Failure | AN           |                           |
#		| 6  | FTP        | [[path]]    | ftp://rsaklfsvrsbspdc:1001/FORTESTING/test.txt                | True     | ""                            | ""       | [[result]] | Failure | AN           |                           |
#		| 7  | FTPS       | [[path]]    | ftp://rsaklfsvrsbspdc:1002/FORTESTING/test/txt                | True     | IntegrationTester             | I73573r0 | [[result]] | Failure | AN           |                           |
		

	
#Scenario Outline: Create File at location1
#    Given I have a variable "[[a]]" with a value '<Val1>'
#	Given I have a variable "[[b]]" with a value '<Val2>'
#	Given I have a variable "[[rec(1).a]]" with a value '<Val1>'
#	Given I have a variable "[[rec(2).a]]" with a value '<Val2>'
#	Given I have a variable "[[index]]" with a value "1"
#	Given I have a source path '<destination>' with value '<destinationLocation>' 
#	And overwrite is '<selected>'
#	And destination credentials as '<username>' and '<password>'
#	And result as '<resultVar>'
#	When validating the tool
#	Then validation is '<ValidationResult>'
#	And validation message is '<DesignValidation>'
#    When the create file tool is executed
#	Then the result variable '<resultVar>' will be '<result>'
#	And the execution has "<errorOccured>" error
#	And execution error message will be '<DesignValidation>'
#	And the debug inputs as
#         | File or Folder                        | Overwrite  | Username   | Password |
#         | <destination> = <destinationLocation> | <selected> | <username> | String   |
#	And the debug output as
#		|                        |
#		| <resultVar> = <result> |
#	Examples: 
#		| No | Name        | destination                    | Val1      | Val2        | destinationLocation | selected | username              | password | resultVar              | result  | errorOccured | ValidationResult | DesignValidation                                                                                                                                                                                                               | OutputError                                                                                                                                                                                                                         |
#		| 1  | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 2  | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 3  | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 4  | Local Files | [[a]].txt                      | c:\myfile |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 5  | Local Files | [[a]][[b]].txt                 | c:\       | myfile      | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 6  | Local Files | [[rec([[index]]).a]]           |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 7  | Local Files | [[a]][[b]]                     | c:\       | myfile.txt  | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 8  | Local Files | [[a]]\[[b]]                    | c:        | myfile.txt  | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 9  | Local Files | [[a]]:[[b]]                    | c         | \myfile.txt | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 10 | Local Files | C:[[a]][[b]].txt               | \myf      | ile         | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 11 | Local Files | [[rec(1).a]][[rec(2).a]]       | c:\myfile | .txt        | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 12 | Local Files | [[rec(1).a]]\[[rec(2).a]]      | c:        | myfile.txt  | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 13 | Local Files | [[rec(1).a]][[rec(2).a]].txt   | c:        | \myfile     | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 14 | Local Files | [[rec(1).a]]:[[rec(2).a]]      | c         | \myfile.txt | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 15 | Local Files | C:[[rec(1).a]][[rec(2).a]].txt | \         | myfile      | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 16 | Local Files | c:\copyfile0.txt               |           |             |                     | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 17 | Local Files | [[rec([[index]]).a]]           |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             | ""                                                                                                                                                                                                                                  |
#		| 18 | Local Files | [[a&]]                         |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | True             | File or Folder - Variable name [[a&]] contains invalid character(s)                                                                                                                                                            | 1.File or Folder - Variable name [[a&]] contains invalid character(s)                                                                                                                                                               |
#		| 19 | Local Files | [[rec(**).a]]                  |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | True             | File or Folder - Recordset index (**) contains invalid character(s)                                                                                                                                                            | 1.File or Folder - Recordset index (**) contains invalid character(s)                                                                                                                                                               |
#		| 20 | Local Files | c(*()                          |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | True             | Please supply a valid File or Folder                                                                                                                                                                                           | 1.Please supply a valid File or Folder                                                                                                                                                                                              |
#		| 21 | Local Files | C:\\\\\gvh                     |           |             |                     | True     | ""                    | ""       | [[result]]             | Success | NO           | False            | ""                                                                                                                                                                                                                             |                                                                                                                                                                                                                                     |
#		| 22 | Local Files | [[rec([[inde$x]]).a]]          |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | True             | File or Folder - Variable name [[index$x]] contains invalid character(s)                                                                                                                                                       | 1.File or Folder - Variable name [[index$x]] contains invalid character(s)                                                                                                                                                          |
#		| 23 | Local Files | [[sourcePath]]                 |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | False            | ""                                                                                                                                                                                                                             | 1.No Value assigned for [[a]]                                                                                                                                                                                                       |
#		| 24 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | [[$#]]                | String   | [[result]]             | ""      | AN           | True             | Username - Variable name [[$#]] contains invalid character(s)                                                                                                                                                                  | 1.Username - Variable name [[$#]] contains invalid character(s)                                                                                                                                                                     |
#		| 25 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | [[a]]\[[b]]           | String   | [[result]]             | ""      | AN           | False            | ""                                                                                                                                                                                                                             | 1.No Value assigned for [[a]] 2.1.No Value assigned for [[b]]                                                                                                                                                                       |
#		| 26 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | [[rec([[index]]).a]]  | String   | [[result]]             | ""      | AN           | False            | ""                                                                                                                                                                                                                             | 1.No Value assigned for [[index]]                                                                                                                                                                                                   |
#		| 27 | Local Files | [[sourcePath]].txt             |           |             | c:\myfile.txt       | True     | [[rec([[index&]]).a]] | String   | [[result]]             | ""      | AN           | True             | Username - Recordset name [[indexx&]] contains invalid character(s)                                                                                                                                                            | Username - Recordset name [[indexx&]] contains invalid character(s)                                                                                                                                                                 |
#		| 28 | Local Files | [[sourcePath]].txt             |           |             | c:\myfile.txt       | True     | [[a]]*]]              | String   | [[result]]             | ""      | AN           | True             | Username - Invalid expression: opening and closing brackets don't match                                                                                                                                                        | 1.Username - Invalid expression: opening and closing brackets don't match                                                                                                                                                           |
#		| 29 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[result]][[a]]        | ""      | AN           | True             | The result field only allows a single result                                                                                                                                                                                   | 1.The result field only allows a single result                                                                                                                                                                                      |
#		| 30 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[a]]*]]               | ""      | AN           | True             | Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                          | 1.Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                             |
#		| 31 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[var@]]               | ""      | AN           | True             | Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                                  | 1.Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                                     |
#		| 32 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[var]]00]]            | ""      | AN           | True             | Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                          | 1.Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                             |
#		| 33 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[(1var)]]             | ""      | AN           | True             | Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                                  | 1.Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                                     |
#		| 34 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[var[[a]]]]           | ""      | AN           | True             | Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                           | 1.Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                              |
#		| 35 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[var.a]]              | ""      | AN           | True             | Result - Variable name [[var.a]]contains invalid character(s)                                                                                                                                                                  | 1.Result - Variable name [[var.a]] contains invalid character(s)                                                                                                                                                                    |
#		| 36 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[@var]]               | ""      | AN           | True             | Result - Variable name [[@var]] contains invalid character(s)                                                                                                                                                                  | 1.Result - Variable name [[@var]] contains invalid character(s)                                                                                                                                                                     |
#		| 37 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[var 1]]              | ""      | AN           | True             | Result - Variable name [[var 1]] contains invalid character(s)                                                                                                                                                                 | 1.Result - Variable name [[var 1]] contains invalid character(s)                                                                                                                                                                    |
#		| 38 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[rec(1).[[rec().1]]]] | ""      | AN           | True             | Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                           | 1.Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                              |
#		| 39 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[rec(@).a]]           | ""      | AN           | True             | Result - Recordset index [[@]] contains invalid character(s)                                                                                                                                                                   | 1.Result - Recordset index [[@]] contains invalid character(s)                                                                                                                                                                      |
#		| 40 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[rec"()".a]]          | ""      | AN           | True             | Result - Recordset name [[rec"()"]] contains invalid character(s)                                                                                                                                                              | 1.Result - Recordset name [[rec"()"]] contains invalid character(s)                                                                                                                                                                 |
#		| 41 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | ""                    | ""       | [[rec([[[[b]]]]).a]]   | ""      | AN           | True             | Result - Invalid Region [[rec([[[[b]]]]).a]]                                                                                                                                                                                   | 1.Result - Invalid Region [[rec([[[[b]]]]).a]]                                                                                                                                                                                      |
#		| 42 | Local Files | [[a]                           |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | True             | File or Folder - Invalid expression: opening and closing brackets don't match                                                                                                                                                  | 1.File or Folder - Invalid expression: opening and closing brackets don't match                                                                                                                                                     |
#		| 43 | Local Files | [[rec]                         |           |             |                     | True     | ""                    | ""       | [[result]]             | ""      | AN           | True             | File or Folder - [[rec]] does not exist in your variable list                                                                                                                                                                  | 1.File or Folder - [[rec]] does not exist in your variable list                                                                                                                                                                     |
#		| 44 | Local Files | [[sourcePath]]                 |           |             | c:\myfile.txt       | True     | Test                  | ""       | [[result]]             | ""      | AN           | True             | Password cannot be empty or only white space                                                                                                                                                                                   | 1.Password cannot be empty or only white space                                                                                                                                                                                      |
#		| 45 | Local Files | A                              |           |             | ""                  | True     | Test                  | ""       | [[result]]             | ""      | AN           | True             | Please supply valid File Name                                                                                                                                                                                                  | 1.Please supply valid File Name                                                                                                                                                                                                     |
#		| 46 | Local Files | [[var@]]                       |           |             |                     | True     | [[var@]]              | ""       | [[var@]]               | ""      | AN           | True             | Username - Variable name [[$#]] contains invalid character(s)   Result - Variable name [[var@]] contains invalid character(s)                                                                                                  | 1.Username - Variable name [[$#]] contains invalid character(s)  2.Result - Variable name [[var@]] contains invalid character(s)                                                                                                    |
#		| 47 | Local Files | C#$%#$]]                       |           |             |                     | True     | C#$%#$]]              | ""       | C#$%#$]]               | ""      | AN           | True             | File or Folder - Invalid expression: opening and closing brackets don't match  Username - Invalid expression: opening and closing brackets don't match   Result - Invalid expression: opening and closing brackets don't match | 1.File or Folder - Invalid expression: opening and closing brackets don't match 2.Username - Invalid expression: opening and closing brackets don't match   3.Result - Invalid expression: opening and closing brackets don't match |                                                      
#			     



























