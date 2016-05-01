Feature: StatsCollector
	In Order to avoid any discrepencies
	With the data The stat collector 
	Should calculate the Write Indicators
	And Display the difference

	# add this as part of the May branch

@mytag
Scenario: Calculate The StatCollector Indicators for Nacre Source:
	Given I have the Following Nacre Row
	| DealId | Name | Id | Version |
	| 1      | John | 26 | 1       |
	| 2      | Kate | 21 | 1       |
	When I Invoke the Stats Collector
	Then the result should be as Below
	| Key | Value |
	| COUNT_All_Id  | 2 |
	| COUNT_DISTINCT_DealId | 1  |
	| COUNT_NULL_Name| 0  |

	
