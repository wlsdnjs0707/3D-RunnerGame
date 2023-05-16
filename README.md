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
   - 눈덩이가 앞으로 가는 것이 아니고 스테이지가 뒤쪽으로 이동합니다.<br/>
   - 스테이지 프리팹중 랜덤으로 다음 스테이지가 생성되고 화면 밖으로 나간 스테이지가 제거됩니다.
<br/><br/><br/>

```python
transform.position = new Vector3((MouseWorldPosition() + offset).x, transform.position.y, transform.position.z);
```
   - 터치(드래그) 좌표를 따라 눈덩이가 이동합니다.
<br/><br/><br/>

   
<img src="https://user-images.githubusercontent.com/86781939/226395843-aa6c9d65-28b9-484a-b0f5-25f58b659387.gif"  width="270" height="600" >
   - OnTriggerEnter 함수로 장애물과 충돌을 감지하고 충돌 시 게임이 종료됩니다.</br>
   - Restart 온클릭이벤트로 씬을 재실행합니다.
<br/>

## - 참고
  - 환경 에셋 (나무) - Nature Pack - Low Poly Trees & Bushes (https://assetstore.unity.com/packages/3d/vegetation/nature-pack-low-poly-trees-bushes-210184)
<br/>

<img src="https://img.shields.io/badge/Unity-212121?style=for-the-badge&logo=Unity&logoColor=white"><img src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=Visual%20Studio&logoColor=white"><img src="https://img.shields.io/badge/C%20Sharp-239120?style=for-the-badge&logo=C%20Sharp&logoColor=white"><img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=GitHub&logoColor=white">
