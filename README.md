# osu-cleaner
Small tool, written in C#, to clean unused elements from beatmaps.

If you are using a SSD, you will be happy! Deleting those elements will save your disk space even by few gigabytes. You can choose what to delete: videos, storyboards, beatmap skins, backgrounds and hitsounds. You can also choose to move those files instead of permanent purge.

## Download
### Latest release: v1.05 (06.11.2018) [Download here!](https://github.com/henntix/osu-cleaner/releases/download/v1.00/osu-cleaner.exe)


## License: The MIT License (MIT)


> Contributors are appreciated. If you want to contribute and add something, fork it and send me a pull request.

> If you find issues or bugs, report them via Issues page. Please also report if something has been not deleted but it should be.

##Changelog
* v1.0 (06.11.2018) Initial release, written in 2016

---

## Known Issues
* Some storyboard elements are not deleted due to not being used on actual storyboard. This cannot be easily fixed due to storyboard elements finding approach. This issue could be fixed by implementing *"unused elements cleaner"* which will delete all files except \*osu, audio files and whitelisted elements mentioned above, selected by user
* \*.osb files are not deleted. 