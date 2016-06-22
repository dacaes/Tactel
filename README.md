# Tactel
Unity utilities and scripts for video game creation.

---

UIManager: Change all your UI with a simple call to method ChangeView(UIViews view).
You can set different elements to every view, and set them to different views.

Thinking about make auto call views. Example: You change to Menu1 doing:
myUIManager.ChangeView(UIVIews.Menu1);

and after end the animations fo the change make call automatically Menu2. Settings delays between atomatic changes would create cool animations.

---

ScoreUI is a simple score manager who shows the score with a spritesheet of numbers.

---

BarUI is a simple life/power bar manager. You can change its size by percentage and do it with an animation. Need to improve some things here. If you make the bar grow another time before the last animation ends it won't do anything. I would like to give the options to animate with different eases and make a previous ghost bar like the one you can see on Dark Souls when you receive a hit.

Probably I will continue it when Unity actualizes with sprites masking (already on downloadable beta: http://blogs.unity3d.com/es/2016/06/13/2d-experimental-preview/)

---

On Utils folder you have some auxiliar scripts, an object pool and in other folders you can find some test and other useful scripts.