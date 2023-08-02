# Number Game -- Unity Programming Test (~2 Hr)

## Demo
A live web demo is available here:
- https://davramov.github.io/NumberGame/

Please enter "Fullscreen" to view the entire game canvas in your browser.

## Description
This is the YouTube tutorial I followed for making a simple number-matching game in Unity:
- https://www.youtube.com/watch?v=rmQm_pSmGRw

In the tutorial, they used words to indicate if a response was right or wrong, which is not a very accessible approach for the target audience of a game like this (4-5-year-olds) who may not be able to read yet and are just starting to learn numbers and simple pattern matching.

In response to this, I extended the example to include: audio feedback that plays for correct ("tada") and incorrect ("womp womp womp") responses and more visual feedback that does not rely on words such as positive and negative emojis, and an arrow graphic instead of a "next" button.

I tried to match the tutorial style, although they did not include any source files for the assets. To overcome this, I used Photoshop to generate the background image and Bing to find royalty-free graphics for the numbers and images. Some of the graphics I found were not transparent, so I had to edit the background in Photoshop and load them into Unity. 

In this repository, you will find a folder containing the Unity project and assets (built in Unity v. 2021.3.13f1), another folder with a Windows EXE build, as well as a WebGL build that runs in the web browser (labeled "docs" for working with GitHub Pages).

