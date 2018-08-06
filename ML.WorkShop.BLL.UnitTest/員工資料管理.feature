Feature: 員工資料管理
	員工資料維護系統

@mytag
Scenario: 新增一筆員工資料
	Given 前端應傳來以下MemberViewModel資料
		| Id | CompanyId | WorkId | RoleName   | Email | Name | Age | Password |
		| 1  | DDMC      | 10608  | Member   |yao@aa.bb | yao  | 18  | 1234  |
	
	When 調用MemberWorkflow.Insert

	Then 預期資料庫的Member資料表應有以下資料
		| Id | WorkId | CompanyId | Email | Name | Age | CreateUserId | CreateDateTime |
		| 1  | 10608  | 0         | yao@aa.bb | yao  | 18  | TEST_USER    | 1900-01-01 00:00:00 |

	And 預期資料庫的Identity資料表應有以下資料
		| Member_Id  | Password | CreateUserId | CreateDateTime |
		| 1           | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 預期資料庫的MemberLog資料表應有以下資料
		| Member_Id | Email     | Name | Age | WorkId | Password | CreateUserId | CreateDateTime      |
		| 1         | yao@aa.bb | yao  | 18  | 10608    | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 預期資料庫的Role資料表應有以下資料
		| Id | Member | CreateDateTime      | CreateUserId |
		| 1  | true      | 1900-01-01 00:00:00 | TEST_USER    |

Scenario: 編輯一筆員工資料
	Given 資料庫的Member資料表已經存在以下資料
		| Id | WorkId | CompanyId | Email | Name | Age | CreateUserId | CreateDateTime |
		| 1  | 10608  | 0         | yao@aa.bb | yao  | 18  | TEST_USER    | 1900-01-01 00:00:00 |

	And 資料庫的Identity資料表已經存在以下資料
		| Member_Id | Password | CreateUserId | CreateDateTime |
		| 1             | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 資料庫的Role資料表已經存在以下資料
		| Id | Member | CreateDateTime      | CreateUserId |
		| 1  | true      | 1900-01-01 00:00:00 | TEST_USER    |

	And 資料庫的MemberLog資料表已經存在以下資料
		| Member_Id | Email     | Name | Age | WorkId | Password | CreateUserId | CreateDateTime      |
		| 1         | yao@aa.bb | yao  | 18  | 10608    | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 前端應傳來以下MemberViewModel資料
		| Id | CompanyId | WorkId | RoleName   |  Email | Name | Age | Password |
		| 1  | DDMC      | 10608  | Member      |Yami@aa.bb | Yami  | 25  | 54321  |

	When 調用MemberWorkflow.Update

	Then 預期資料庫的Member資料表應有以下資料
		| Id | WorkId | CompanyId | Email      | Name | Age | CreateUserId | CreateDateTime      | LastModifyUserId | LastModifyDateTime  |
		| 1  | 10608  | 0         | Yami@aa.bb | Yami | 25  | TEST_USER    | 1900-01-01 00:00:00 | TEST_USER        | 1900-01-01 00:00:00 |
	
	And 預期資料庫的Identity資料表應有以下資料
		| Member_Id  | Password | CreateUserId | CreateDateTime |LastModifyUserId | LastModifyDateTime  |
		| 1             | 54321     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |

	And 預期資料庫的MemberLog資料表應有以下資料
		| Member_Id | Email      | Name | Age | WorkId | Password | CreateUserId | CreateDateTime      | LastModifyUserId | LastModifyDateTime  |
		| 1         | yao@aa.bb  | yao  | 18  | 10608  | 1234     | TEST_USER    | 1900-01-01 00:00:00 |                  |                     |
		| 1         | Yami@aa.bb | Yami | 25  | 10608  | 54321    |              |                     | TEST_USER        | 1900-01-01 00:00:00 |
		
	And 預期資料庫的Role資料表應有以下資料
		| Id | Member | CreateDateTime      | CreateUserId |LastModifyUserId | LastModifyDateTime  |
		| 1  | true      | 1900-01-01 00:00:00 | TEST_USER    |TEST_USER        | 1900-01-01 00:00:00 |

Scenario: 刪除一筆員工資料
	Given 資料庫的Member資料表已經存在以下資料
		| Id | WorkId | CompanyId | Email | Name | Age | CreateUserId | CreateDateTime |
		| 1  | 10608  | 0         | yao@aa.bb | yao  | 18  | TEST_USER    | 1900-01-01 00:00:00 |

	And 資料庫的Identity資料表已經存在以下資料
		| Member_Id  | Password | CreateUserId | CreateDateTime |
		| 1               | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 資料庫的Role資料表已經存在以下資料
		| Id | Member | CreateDateTime      | CreateUserId |
		| 1  | true      | 1900-01-01 00:00:00 | TEST_USER    |

	And 資料庫的MemberLog資料表已經存在以下資料
		| Member_Id | Email     | Name | Age | WorkId | Password | CreateUserId | CreateDateTime      |
		| 1         | yao@aa.bb | yao  | 18  | 10608    | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 前端應傳來以下MemberViewModel資料
		| Id | CompanyId | WorkId | RoleName    | Email | Name | Age | Password |
		| 1  | DDMC      | 10608  | Member       |yao@aa.bb | yao  | 18  | 1234  |

	When 調用MemberWorkflow.Delete

	Then 預期資料庫的Member資料表應有以下資料
		| Id | WorkId | CompanyId | Email      | Name | Age | CreateUserId | CreateDateTime      | LastModifyUserId | LastModifyDateTime  |
		
	
	And 預期資料庫的Identity資料表應有以下資料
		| Member_Id  | Password | CreateUserId | CreateDateTime |LastModifyUserId | LastModifyDateTime  |
	
	And 預期資料庫的Role資料表應有以下資料
		| Id | Member | CreateDateTime      | CreateUserId |LastModifyUserId | LastModifyDateTime  |

	And 預期資料庫的MemberLog資料表應有以下資料
		| Member_Id | Email     | Name | Age | WorkId | Password | CreateUserId | CreateDateTime      | LastModifyUserId | LastModifyDateTime | DeleteUserId | DeleteDateTime |
		| 1         | yao@aa.bb | yao  | 18  | 10608  | 1234     | TEST_USER    | 1900-01-01 00:00:00 |                  |                    |              |                |
		| 1         | yao@aa.bb | yao  | 18  | 10608  | 1234     |              |  |                  |                    | TEST_USER    | 1900-01-01 00:00:00 |

Scenario: 顯示員工資料表
	Given 資料庫的Member資料表已經存在以下資料
		| Id | WorkId | CompanyId | Email      | Name | Age | CreateUserId | CreateDateTime      |
		| 1  | 10608  | 0         | yao1@aa.bb | yao1 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 2  | 10609  | 0         | yao2@aa.bb | yao2 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 3  | 10610  | 0         | yao3@aa.bb | yao3 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 4  | 10611  | 0         | yao4@aa.bb | yao4 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 5  | 10612  | 0         | yao5@aa.bb | yao5 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 6  | 10613  | 0         | yao6@aa.bb | yao6 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
	
	And 資料庫的Identity資料表已經存在以下資料
		| Member_Id | Password | CreateUserId | CreateDateTime      |
		| 1         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 2         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 3         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 4         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 5         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 6         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 資料庫的Role資料表已經存在以下資料
		| Id | Administrator | Member | Lock  | CreateDateTime      | CreateUserId |
		| 1  | true          | false  | false | 1900-01-01 00:00:00 | TEST_USER    |
		| 2  | false         | true   | false | 1900-01-01 00:00:00 | TEST_USER    |
		| 3  | false         | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |
		| 4  | false         | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |
		| 5  | true          | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |
		| 6  | false         | true   | true  | 1900-01-01 00:00:00 | TEST_USER    |

	And 資料庫的MemberActivity資料表已經存在以下資料
		| Id | Member_Id | LoginDateTime       | LastModifyPasswordDate |
		| 1  | 1         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 2  | 2         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 3  | 3         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 4  | 4         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 5  | 5         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 6  | 6         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
	And 前端應傳來以下MemberFilterModel資料
		| Email      | Name | Age | WorkId | ComapnyId|

	And 前端應傳來以下GridState資料
		| PageSize | PageIndex |
		| 10       | 0         |
	When 調用MemberWorkflow.GetMembers
		
	Then 預期查詢得到以下MemberListViewModel資料
		| Id | CompanyName  | WorkId | Name | Email      | Admin | Member | Lock  | LastLoginDateTime   | LastModifyPasswordDate |
		| 1  | 鼎鼎企業管理股份有限公司 | 10608  | yao1 | yao1@aa.bb | true  | false  | false | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 2  | 鼎鼎企業管理股份有限公司 | 10609  | yao2 | yao2@aa.bb | false | true   | false | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 3  | 鼎鼎企業管理股份有限公司 | 10610 | yao3 | yao3@aa.bb | false | false  | true  | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 4  | 鼎鼎企業管理股份有限公司 | 10611 | yao4 | yao4@aa.bb | false | false  | true  | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 5  | 鼎鼎企業管理股份有限公司 | 10612 | yao5 | yao5@aa.bb | true  | false  | true  | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 6  | 鼎鼎企業管理股份有限公司 | 10613 | yao6 | yao6@aa.bb | false  | true   | true  | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
	
Scenario: 查詢特定員工資料
	Given 資料庫的Member資料表已經存在以下資料
		| Id | WorkId | CompanyId | Email      | Name | Age | CreateUserId | CreateDateTime      |
		| 1  | 10608  | 0         | yao1@aa.bb | yao1 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 2  | 10609  | 0         | yao2@aa.bb | yao2 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 3  | 10610  | 0         | yao3@aa.bb | yao3 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 4  | 10611  | 0         | yao4@aa.bb | yao4 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 5  | 10612  | 0         | yao5@aa.bb | yao5 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
		| 6  | 10613  | 0         | yao6@aa.bb | yao6 | 18  | TEST_USER    | 1900-01-01 00:00:00 |
	
	And 資料庫的Identity資料表已經存在以下資料
		| Member_Id | Password | CreateUserId | CreateDateTime      |
		| 1         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 2         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 3         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 4         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 5         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |
		| 6         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |

	And 資料庫的Role資料表已經存在以下資料
		| Id | Administrator | Member | Lock  | CreateDateTime      | CreateUserId |
		| 1  | true          | false  | false | 1900-01-01 00:00:00 | TEST_USER    |
		| 2  | false         | true   | false | 1900-01-01 00:00:00 | TEST_USER    |
		| 3  | false         | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |
		| 4  | false         | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |
		| 5  | true          | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |
		| 6  | false         | true   | true  | 1900-01-01 00:00:00 | TEST_USER    |

	And 資料庫的MemberActivity資料表已經存在以下資料
		| Id | Member_Id | LoginDateTime       | LastModifyPasswordDate |
		| 1  | 1         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 2  | 2         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 3  | 3         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 4  | 4         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 5  | 5         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 6  | 6         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
	And 前端應傳來以下MemberFilterModel資料
		| Email      | Name | Age | WorkId | ComapnyName | Admin | Member | Lock  |
		| yao1@aa.bb | yao1 | 18  | 10608  | 鼎鼎        | true  | false  | false |
	And 前端應傳來以下GridState資料
		| PageSize | PageIndex |
		| 10       | 0         |
	When 調用MemberWorkflow.GetMembers

	Then 預期查詢得到以下MemberListViewModel資料
		| Id | CompanyName              | WorkId | Name | Email      | Admin | Member | Lock  | LastLoginDateTime   | LastModifyPasswordDate |
		| 1  | 鼎鼎企業管理股份有限公司 | 10608  | yao1 | yao1@aa.bb | true  | false  | false | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |

Scenario: 查詢某員工詳細資料
	Given 資料庫的Member資料表已經存在以下資料
		| Id | WorkId | CompanyId | Email      | Name | Age | CreateUserId | CreateDateTime      | LastModifyUserId | LastLoginDateTime   |
		| 1  | 10608  | 0         | yao1@aa.bb | yao1 | 18  | TEST_USER    | 1900-01-01 00:00:00 | TEST_USER        | 1900-01-01 00:00:00 |
		| 2  | 10609  | 0         | yao2@aa.bb | yao2 | 18  | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 3  | 10610  | 0         | yao3@aa.bb | yao3 | 18  | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 4  | 10611  | 0         | yao4@aa.bb | yao4 | 18  | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 5  | 10612  | 0         | yao5@aa.bb | yao5 | 18  | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 6  | 10613  | 0         | yao6@aa.bb | yao6 | 18  | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
	
	And 資料庫的Identity資料表已經存在以下資料
		| Member_Id | Password | CreateUserId | CreateDateTime      | LastModifyUserId | LastLoginDateTime   |
		| 1         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 2         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 3         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 4         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 5         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |
		| 6         | 1234     | TEST_USER    | 1900-01-01 00:00:00 |TEST_USER        | 1900-01-01 00:00:00 |

	And 資料庫的Role資料表已經存在以下資料
		| Id | Administrator | Member | Lock  | CreateDateTime      | CreateUserId | LastModifyUserId | LastLoginDateTime   |
		| 1  | true          | false  | false | 1900-01-01 00:00:00 | TEST_USER    |TEST_USER        | 1900-01-01 00:00:00 |
		| 2  | false         | true   | false | 1900-01-01 00:00:00 | TEST_USER    |TEST_USER        | 1900-01-01 00:00:00 |
		| 3  | false         | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |TEST_USER        | 1900-01-01 00:00:00 |
		| 4  | false         | false  | true  | 1900-01-01 00:00:00 | TEST_USER    |TEST_USER        | 1900-01-01 00:00:00 |
		| 5  | true          | false  | true  | 1900-01-01 00:00:00 | TEST_USER   |TEST_USER        | 1900-01-01 00:00:00 |
		| 6  | false         | true   | true  | 1900-01-01 00:00:00 | TEST_USER    |TEST_USER        | 1900-01-01 00:00:00 |

	And 資料庫的MemberActivity資料表已經存在以下資料
		| Id | Member_Id | LoginDateTime       | LastModifyPasswordDate |
		| 1  | 1         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 2  | 2         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 3  | 3         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 4  | 4         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 5  | 5         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
		| 6  | 6         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |

	And 前端應傳來以下MemberFilterModel資料
		| Id |
		| 1  |

	When 調用MemberWorkflow.GetMemberDetail

	Then 預期查詢得到以下MemberDetailViewModel資料
		| Id | CompanyName  | Age | Password | WorkId | Name | Email | Admin | Member | Lock | CreateDateTime | CreateUserId | LastModifyUserId | LastLoginDateTime | LastLoginDateTime | LastModifyPasswordDate |
		| 1  | 鼎鼎企業管理股份有限公司 | 18  | 1234     | 10608  | yao1 | yao1@aa.bb | true  | false  | false | 1900-01-01 00:00:00 | TEST_USER    | TEST_USER        | 1900-01-01 00:00:00         | 1900-01-01 00:00:00 | 1900-01-01 00:00:00    |
