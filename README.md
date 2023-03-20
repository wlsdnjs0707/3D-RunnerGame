# 3D Endless Runner Game (Unity)
<br/>

## - 기능 및 소개
<img src="https://user-images.githubusercontent.com/86781939/226393913-6a1f9008-8c74-426c-846b-9da9d9d6314f.gif"  width="270" height="600" >

   눈 굴리기 게임

   1. 맵, 배경 이동
   2. 터치 & 드래그로 플레이어 이동
   3. 점수출력 및 충돌 이벤트
<br/>

## - 기능
<img src="https://user-images.githubusercontent.com/86781939/226394234-18966f08-8a29-4d0b-b494-567c5a694633.gif">
   - 플레이어가 아닌 맵이 뒤쪽으로 이동<br/>
   - 스테이지 프리팹중 랜덤으로 다음 스테이지 생성, 화면 밖으로 나간 스테이지 제거
<br/><br/><br/>

```python
transform.position = new Vector3((((touchPoint.x * 9.0f) / 540) + 1), transform.position.y, transform.position.z);
```
   - 화면과 게임의 좌표 비율을 계산하여 터치한 곳에 따라 플레이어 position 이동
<br/><br/><br/>

   
<img src="https://user-images.githubusercontent.com/86781939/226395843-aa6c9d65-28b9-484a-b0f5-25f58b659387.gif"  width="270" height="600" >
   - OnTriggerEnter 함수로 장애물과 충돌 감지, 충돌시 게임 종료</br>
   - Restart 온클릭이벤트로 씬 재실행
<br/>

## - 참고
  - 환경 에셋 (나무) - Nature Pack - Low Poly Trees & Bushes (https://assetstore.unity.com/packages/3d/vegetation/nature-pack-low-poly-trees-bushes-210184)
<br/>

<img src="https://img.shields.io/badge/Unity-212121?style=for-the-badge&logo=Unity&logoColor=white"><img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=Visual%20Studio&logoColor=white"><img src="https://img.shields.io/badge/C%20Sharp-239120?style=for-the-badge&logo=C%20Sharp&logoColor=white"><img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=GitHub&logoColor=white">
