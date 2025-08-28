# GitTracker

## 개발 배경

CC 인증을 위해 형상대상인 TOE(Target Of Elements)의 소스코드 와 라이브러리에 대한 문서를 만들기 위해 `git log`로 찾기 시작했습니다.  
그러나 해달 git 리포지토리가 오래되고 많은 변화가 있어서 로그 양이 많아 사람이 직접 하기 어려움이 있었습니다.
이를 해결하고자 git log 를 조사하여 파일에 대한 상태 변경이력을 조회하는 프로그램을 개발 했습니다.

## 사용 방법

```bash
GitTracker -s <git_repo_path> -d <output_file> -b <branch_name> -since <start_datetime> -duplicatedMode

-s, --source : Git 리포지토리 경로를 지정합니다. (기본값: 현재 경로)
-d, --dest: 결과 출력파일입니다. (기본값: ./ouput)
-since: git log를 추출할 시작 일자를 지정합니다. (기본값: 오늘날)
-duplicatedMode: 로그에서 중복된 파일에 대해서는 출력 방지 옵션입니다.
```

