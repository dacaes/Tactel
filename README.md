# Tactel
Unity utilities and scripts for video game creation.

If you distribute binaries, give attribution on credits:

UIManager by Daniel Castaño Estrella
daniel.c.estrella@gmail.com
https://github.com/danielcestrella


If you want to contribute, branch the project.

---

UIManager: Change all your UI with a simple call to method ChangeView(UIViews view).
You can set different elements to every view, and set them to different views.

Create animations using ViewName_Number pattern.

Example: Anim_1, Anim_2, Anim_3.

If you change view to Anim_2 you will see Anim_1 before.
You can avoid animations using ChangeView(view, true);

You can chose to see backtrack animations, true by default.

Example:

Anim_1, Anim_2
Menu_1, Menu_2

You are on *Anim_2*, and you change to *Menu_2*. With backtrack animation you will see: Anim_2 -> Anim_1 -> Menu_1 -> Menu_2.

On movable elements you can choose manually **IN** and **OUT** transforms, but UIManager finds automatically **UIManagerPositions** GameObject and looks for *ObjectNameIn* and *ObjectNameOut* transforms. You can use a gameObject for 2 elements position naming like *ObjectName1Out ObjectName2Out*.

If UIManager doesn't find IN transform, it gets object initial position by default.

Thinking about adding delays.

---

ScoreUI is a simple score manager who shows the score with a spritesheet of numbers.

---

BarUI is a simple life/power bar manager. You can change its size by percentage and do it with an animation. Need to improve some things here. If you make the bar grow another time before the last animation ends it won't do anything. I would like to give the options to animate with different eases and make a previous ghost bar like the one you can see on Dark Souls when you receive a hit.

Probably I will continue it when Unity actualizes with sprites masking (already on downloadable beta: http://blogs.unity3d.com/es/2016/06/13/2d-experimental-preview/)

---

On Utils folder you have some auxiliar scripts, an object pool and in other folders you can find some test and other useful scripts.