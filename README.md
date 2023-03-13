
# Common experience sample

[日本語版README](https://github.com/open-video-game-library/CommonExperienceSample/blob/main/README.JP.md)


Common experience sample is an Open Source Software (OSS) for evaluating tactile displays. You can adjust and experience basic actions such as grasping and holding the display. For each of the six dimensional object characteristics (texture, hardness, temperature, weight, shape, and motion) that the tactile display provides feedback on, samples that are frequently used in existing research can be used. The common experience sample is intended to be a standard evaluation stimulus for tactile displays and to promote comparison between displays.
 
<img width="1920" alt="CES" src="https://user-images.githubusercontent.com/71160720/222035262-993b3a32-0bf1-4afc-9bbb-675139798970.png">



[Click here for a detailed demo video.](https://www.youtube.com/watch?v=3QshPIVFACQ)



## Features



#### Parameter adjustment and output function
	
Various parameters that are in high demand for adjustment in the sample can be easily adjusted on the GUI. In addition, the adjusted parameter information can be exported and read to reflect the differences. This allows you to reflect the parameter information of other researchers and unify the experimental conditions.


https://user-images.githubusercontent.com/71160720/186425256-223169bc-e52f-4aaf-98e5-c1e7213b05b5.mov		


		

### Examples of Use


1. Conduct an evaluation experiment of the tactile display developed using the common experience sample.
2. Use common experience samples in conference demonstration presentations.

## Requirement

* Unity 2021.3.4f1
* Oculus XR Plugin 3.0.2
* XR Plugin Management 4.2.1

## Installation

[You can install any version of Unity here.](https://unity3d.com/jp/get-unity/download/archive)

## Usage

Please clone this repository to your local environment using the following command.

```bash
git clone git@github.com:open-video-game-library/CoExperienceSamples.git
```


## Licence
The license to use the common experience sample is the [MIT license](https://github.com/open-video-game-library/CommonExperienceSample/blob/main/LICENSE.md) and the original license. In order for other researchers to reproduce your experimental environment, please comply with the original license as well.
  
### Original License
  
 When using software provided by the Open Video Game Library with modifications for research purposes, you must disclose the software version and its source code, and cite the paper described in the README file included with the software you are using.
   

## Citation
Common Experience Sample 1.0: Developing a sample for comparing the characteristics of haptic displays

[Go to publication page](https://dl.acm.org/doi/10.1145/3562939.3565649)

### BibTeX
```
@inproceedings{10.1145/3562939.3565649,
author = {Oka, Takuya and Morimoto, Kosuke and Yanase, Yohei and Watanabe, Keita},
title = {Common Experience Sample 1.0: Developing a Sample for Comparing the Characteristics of Haptic Displays},
year = {2022},
isbn = {9781450398893},
publisher = {Association for Computing Machinery},
address = {New York, NY, USA},
url = {https://doi.org/10.1145/3562939.3565649},
doi = {10.1145/3562939.3565649},
abstract = {Many haptic displays that provide haptic feedback to users have been proposed;however, differences in experimental environments make comparisons of displays difficult. Therefore, we categorized the characteristics of feedback based on existing research, and developed a common experience sample that includes virtual objects necessary for the expression of each characteristic. Additionally, we will study the methods of evaluating displays using the proposed sample, and aim at comparative evaluation of multiple displays.},
booktitle = {28th ACM Symposium on Virtual Reality Software and Technology},
articleno = {47},
numpages = {2},
keywords = {haptic, virtual reality, crossmodal, sample, evaluation, multimodal},
location = {Tsukuba, Japan},
series = {VRST '22}
}
```

## Contact

If you have any comments, requests or questions, please contact us [here](https://openvideogame.cc/contact).

