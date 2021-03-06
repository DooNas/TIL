# 백준 6975번 문제(영문판)  

## __내용__
---
양의 정수를 입력으로 받고 정수가 11로 나뉘어 떨어지는지  
여부를 확인하기 위해 아래에 설명된 알고리즘을 사용하여 검사하는 프로그램을 작성하십시오.  
  
##### *11로 나눌수 있는 이 테스트는*  
##### *1897년 Charles L. Dodgson(Lewis Carroll).*  


## __방식__
---
테스트 중인 숫자 2자리 이상인 경우 다음을 수행하여 새 숫자를 만드십시오.  
- 단위 자릿수 삭제
- 단축된 숫자에서 삭제된 숫자 빼기
- 나머지 숫자는 원래 숫자가 11로 나뉘어 떨어지는 경우에만 11로 나눌 수 있습니다.  


## __입력__
---
평소와 같이 입력의 첫 번째 숫자는 뒤에 오는 양의 정수의 수를 나타냅니다.  
각 양의 정수는 최대 50자리입니다.  
양의 정수에는 선행 0이 존재하지 않는다고 가정할 수 있습니다.
  
## __출력__
---
입력의 각 양의 정수에 대해 출력은 숫자를 삭제하고 빼면서 형성된 일련의 숫자로 구성되며,  
그 뒤에 원래 숫자가 11로 나누어 떨어지는지 여부를 나타내는 메시지가 표시됩니다.  
  
## __예제 입력 1__
---  
```
1
12345678901234567900
```
## __예제 출력 1__
---  
```
12345678901234567900
1234567890123456790
123456789012345679
12345678901234558
1234567890123447
123456789012337
12345678901226
1234567890116
123456789005
12345678895
1234567884
123456784
12345674
1234563
123453
12342
1232
121
11
The number 12345678901234567900 is divisible by 11.
```
  
## __예제 입력 2__
---  
```
1
1234567879
```
## __예제 출력 2__
---  
```
1234567879
123456778
12345669
1234557
123448
12336
1227
115
6
The number 1234567879 is not divisible by 11.
```