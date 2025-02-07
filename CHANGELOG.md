<a name="unreleased"></a>
## [Unreleased]


<a name="v1.0.18"></a>
## [v1.0.18] - 2025-02-07
### Fix
- **board:** cleaned BuildBoard method

### Pull Requests
- Merge pull request [#69](https://github.com/montipirlo21/OpenMonday/issues/69) from montipirlo21/68-add-updated_at-the-last-time-the-board-was-updated-to-board-information


<a name="v1.0.17"></a>
## [v1.0.17] - 2025-01-22
### Feat
- **updated_at:** add updated_at information to GetBoardsStructureById and GetActivityLog

### Pull Requests
- Merge pull request [#66](https://github.com/montipirlo21/OpenMonday/issues/66) from montipirlo21/64-read-activity-logs


<a name="v1.0.16"></a>
## [v1.0.16] - 2024-12-27
### Feat
- **ActivityLogs:** read Activity logs

### Pull Requests
- Merge pull request [#63](https://github.com/montipirlo21/OpenMonday/issues/63) from montipirlo21/62-add-monday-users-information


<a name="v1.0.15"></a>
## [v1.0.15] - 2024-12-27
### Feat
- **Users:** Retrieve user base information

### Pull Requests
- Merge pull request [#61](https://github.com/montipirlo21/OpenMonday/issues/61) from montipirlo21/60-timelinevalue-stop-parsing-json-and-refine-graphql-query


<a name="v1.0.14"></a>
## [v1.0.14] - 2024-12-24
### Feat
- **driver:** Completed refactoring parsing timeline column data

### Pull Requests
- Merge pull request [#59](https://github.com/montipirlo21/OpenMonday/issues/59) from montipirlo21/58-add-getboardsstructurebyid-to-boardservice


<a name="v1.0.13"></a>
## [v1.0.13] - 2024-12-24
### Feat
- **BoardService:** retrieve board structure

### Pull Requests
- Merge pull request [#57](https://github.com/montipirlo21/OpenMonday/issues/57) from montipirlo21/56-add-display-name-to-board-columns


<a name="v1.0.12"></a>
## [v1.0.12] - 2024-12-23
### Feat
- **column value:** Add display value to all columns

### Pull Requests
- Merge pull request [#55](https://github.com/montipirlo21/OpenMonday/issues/55) from montipirlo21/54-update-addopenmondayservices-for-dependency-injection-service


<a name="v1.0.11"></a>
## [v1.0.11] - 2024-12-23
### Pull Requests
- Merge pull request [#53](https://github.com/montipirlo21/OpenMonday/issues/53) from montipirlo21/52-create-monday-team-service-api


<a name="v1.0.10"></a>
## [v1.0.10] - 2024-12-23
### Feat
- **driver:** completed driver team retrieve

### Fix
- **driver:** renamed monday driver service and created mondaydriverteamservice

### Pull Requests
- Merge pull request [#51](https://github.com/montipirlo21/OpenMonday/issues/51) from montipirlo21/50-fix-add-groupid-to-board_item


<a name="v1.0.9"></a>
## [v1.0.9] - 2024-12-18
### Feat
- **item:** add groupid to items


<a name="v1.0.8"></a>
## [v1.0.8] - 2024-12-18
### Feat
- **boardStructure:** update query end models for new fields
- **status:** Completed parsing of status settings
- **structure:** add groups informations to structure

### Pull Requests
- Merge pull request [#49](https://github.com/montipirlo21/OpenMonday/issues/49) from montipirlo21/44-add-group-id-and-name-to-items
- Merge pull request [#47](https://github.com/montipirlo21/OpenMonday/issues/47) from montipirlo21/46-enchance-column-definition
- Merge pull request [#45](https://github.com/montipirlo21/OpenMonday/issues/45) from montipirlo21/43-build-a-method-buildwithouttemplate


<a name="v1.0.7"></a>
## [v1.0.7] - 2024-12-05
### Feat
- **BoardMapping:** rename all templates to board mappings

### Fix
- **controller:** refactoring controller

### Pull Requests
- Merge pull request [#42](https://github.com/montipirlo21/OpenMonday/issues/42) from montipirlo21/41-enhance-driver-and-compose-peoplevalue-column


<a name="v1.0.6"></a>
## [v1.0.6] - 2024-12-03
### Feat
- **Board_Column_People:** Added Updatet_At field
- **PeopleValue:** Big refactoring of peoplevalue converter

### Fix
- **documentation:** removed type from template

### Pull Requests
- Merge pull request [#40](https://github.com/montipirlo21/OpenMonday/issues/40) from montipirlo21/39-strawberryshakeserver-to-main-version=1420


<a name="v1.0.5"></a>
## [v1.0.5] - 2024-12-03
### Feat
- **composer:** simplified composer BuildBoard service
- **template:** removed the type for the template board

### Fix
- **RetrieveAndBuildBoard:** Add try catch exceptions
- **StrawberryShake:** Back to main version 14.2.0, now support net core 9

### Pull Requests
- Merge pull request [#38](https://github.com/montipirlo21/OpenMonday/issues/38) from montipirlo21/34-simplify-template-structure-using-refelction-insted-of-typeof-column
- Merge pull request [#37](https://github.com/montipirlo21/OpenMonday/issues/37) from montipirlo21/36-add-id-information-to-items-for-future-mutations
- Merge pull request [#33](https://github.com/montipirlo21/OpenMonday/issues/33) from montipirlo21/32-api-reference-boardservicesretrieveandbuildboard


<a name="v1.0.4"></a>
## [v1.0.4] - 2024-12-02
### Feat
- **composer:** completed first version of composer layer
- **documentation:** add documentation of retrieveandbuildboard

### Fix
- **documentation:** restructured documentation
- **documentation:** fixed nuget package documentation guide
- **fragment:** Add fragment for Item
- **index:** fixed index links

### Pull Requests
- Merge pull request [#31](https://github.com/montipirlo21/OpenMonday/issues/31) from montipirlo21/25-organize-documentation-pages-separate-developing-and-usage
- Merge pull request [#30](https://github.com/montipirlo21/OpenMonday/issues/30) from montipirlo21/29-create-mondaymapper-board-and-items
- Merge pull request [#28](https://github.com/montipirlo21/OpenMonday/issues/28) from montipirlo21/24-mondaydriverboarditemsconverterservice-need-rework-and-optimizations
- Merge pull request [#27](https://github.com/montipirlo21/OpenMonday/issues/27) from montipirlo21/26-fixing-nuget-package-documentation


<a name="v1.0.3"></a>
## [v1.0.3] - 2024-12-01
### Feat
- **driver:** Add first implementation of GetBoardItemsByCursor

### Fix
- **warning:** remove warning for possibile null references in tests

### Pull Requests
- Merge pull request [#23](https://github.com/montipirlo21/OpenMonday/issues/23) from montipirlo21/21-create-graphql-query-for-reading-tasks-supporting-cursors
- Merge pull request [#20](https://github.com/montipirlo21/OpenMonday/issues/20) from montipirlo21/19-create-release-102


<a name="v1.0.2"></a>
## [v1.0.2] - 2024-11-30
### Pull Requests
- Merge pull request [#18](https://github.com/montipirlo21/OpenMonday/issues/18) from montipirlo21/17-validate-update-procedure-nuget-deploy


<a name="v1.0.1"></a>
## [v1.0.1] - 2024-11-30
### Feat
- **changelog:** Add changelog features

### Pull Requests
- Merge pull request [#16](https://github.com/montipirlo21/OpenMonday/issues/16) from montipirlo21/15-github-action-for-self-nuget-deoploying
- Merge pull request [#13](https://github.com/montipirlo21/OpenMonday/issues/13) from montipirlo21/montipirlo21-patch-1
- Merge pull request [#12](https://github.com/montipirlo21/OpenMonday/issues/12) from montipirlo21/3-create-first-page-of-documentation-project-structure-and-strawberry-shake
- Merge pull request [#11](https://github.com/montipirlo21/OpenMonday/issues/11) from montipirlo21/10-automation-for-changelog


<a name="v1.0.0"></a>
## v1.0.0 - 2024-11-30
### Pull Requests
- Merge pull request [#9](https://github.com/montipirlo21/OpenMonday/issues/9) from montipirlo21/8-create-first-nuget-package
- Merge pull request [#7](https://github.com/montipirlo21/OpenMonday/issues/7) from montipirlo21/6-run-first-call-directly-to-a-monday-real-world
- Merge pull request [#5](https://github.com/montipirlo21/OpenMonday/issues/5) from montipirlo21/2-create-first-call-getboardsstructurebyid-with-tests
- Merge pull request [#4](https://github.com/montipirlo21/OpenMonday/issues/4) from montipirlo21/1-create-base-structure-of-the-solution


[Unreleased]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.18...HEAD
[v1.0.18]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.17...v1.0.18
[v1.0.17]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.16...v1.0.17
[v1.0.16]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.15...v1.0.16
[v1.0.15]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.14...v1.0.15
[v1.0.14]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.13...v1.0.14
[v1.0.13]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.12...v1.0.13
[v1.0.12]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.11...v1.0.12
[v1.0.11]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.10...v1.0.11
[v1.0.10]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.9...v1.0.10
[v1.0.9]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.8...v1.0.9
[v1.0.8]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.7...v1.0.8
[v1.0.7]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.6...v1.0.7
[v1.0.6]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.5...v1.0.6
[v1.0.5]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.4...v1.0.5
[v1.0.4]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.3...v1.0.4
[v1.0.3]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.2...v1.0.3
[v1.0.2]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.1...v1.0.2
[v1.0.1]: https://github.com/montipirlo21/OpenMonday/compare/v1.0.0...v1.0.1
