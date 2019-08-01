Public Class Strings
    Public Shared OK As String = "OK"
    Public Shared Cancel As String = "Cancel"
    Public Shared None As String = "None"

    Public Class StatusBar
        Public Shared Length As String = "Length"
        Public Shared LongNote As String = "LongNote"
        Public Shared Hidden As String = "Hidden"
        Public Shared Err As String = "Error"
    End Class

    Public Class Messages
        Public Shared Err As String = "Error"
        Public Shared SaveOnExit As String = "Do you want to save changes?"

        Public Shared _
            SaveOnExit1 As String = "You should tell me if you want to save changes before closing the computer. -_,-"

        Public Shared _
            SaveOnExit2 As String =
                "You still need to tell me if you want to save changes even though you are closing the application with task manager. -_,-"

        Public Shared PromptEnter As String = "Please enter a label."
        Public Shared PromptEnterNumeric As String = "Please enter a value."
        Public Shared PromptEnterMeasure As String = "Please enter a measure (0-999)."
        Public Shared PromptEnterBPM As String = "Please enter a BPM value."
        Public Shared PromptEnterSTOP As String = "Please enter a STOP value."
        Public Shared PromptEnterSCROLL As String = "Please enter a SCROLL value."
        Public Shared PromptSlashValue As String = "When the slash key (""/"") is pressed, change grid division to:"
        Public Shared InvalidLabel As String = "Invalid label."
        Public Shared CannotFind As String = "Cannot find file {}."
        Public Shared PleaseRespecifyPath As String = "Please respecify path."
        Public Shared PlayerNotFound As String = "Player not found"
        Public Shared PreviewDelError As String = "There must exist at least one player."
        Public Shared NegativeFactorError As String = "Factor must be greater than zero."
        Public Shared NegativeDivisorError As String = "Divisor must be greater than zero."

        Public Shared _
            PreferencePostpone As String = "The preference will take effect on the next start-up of the program."

        Public Shared EraserObsolete As String = "The eraser tool has been replaced by right-clicking on the note."
        Public Shared SaveWarning As String = "Warning: "

        Public Shared _
            NoteOverlapError As String =
                "Note operlapping detected. Increasing Maximum Grid Partition will resolve this."

        Public Shared BPMOverflowError As String = "Numbers of multi-byte BPMs has exceeded supported maximum: "
        Public Shared STOPOverflowError As String = "Numbers of STOPs has exceeded supported maximum: "
        Public Shared SCROLLOverflowError As String = "Numbers of multi-byte SCROLLs has exceeded supported maximum: "
        Public Shared SavedFileWillContainErrors As String = "The saved file will contain errors."
        Public Shared FileAssociationPrompt As String = "Do you want to set iBMSC as default program to all {} files?"
        Public Shared FileAssociationError As String = "Error changing file type association:"
        Public Shared RestoreDefaultSettings As String = "Restore default settings?"

        Public Shared _
            RestoreAutosavedFile As String = "{} autosaved file(s) have been found. Do you want to recover these files?"
    End Class

    Public Class FileType
        Public Shared _all As String = "All files (*.*)"

        Public Shared _bms As String = "Supported BMS Format (*.bms, *.bme, *.bml, *.pms, *.txt)"
        Public Shared BMS As String = "Be-Music Script (*.bms)"
        Public Shared BME As String = "Be-Music Extended Format (*.bme)"
        Public Shared BML As String = "Be-Music Longnote Format (*.bml)"
        Public Shared PMS As String = "Po-Mu Script (*.pms)"
        Public Shared TXT As String = "Text document (*.txt)"

        Public Shared SM As String = "StepMania Script (*.sm)"
        Public Shared IBMSC As String = "iBMSC Binary Format (*.ibmsc)"
        Public Shared XML As String = "Extensible Markup Language (*.xml)"
        Public Shared THEME_XML As String = "iBMSC Theme File (*.Theme.xml)"
        Public Shared TH As String = "iBMSC 2.x Theme File (*.Theme.xml)"

        Public Shared _audio As String = "Supported Audio Format (*.wav, *.ogg, *.mp3, *.mid)"
        Public Shared _wave As String = "Supported Wave Audio Format (*.wav, *.ogg, *.mp3)"
        Public Shared WAV As String = "Waveform Audio (*.wav)"
        Public Shared OGG As String = "Ogg Vorbis Audio (*.ogg)"
        Public Shared MP3 As String = "MPEG Layer-3 Audio (*.mp3)"
        Public Shared MID As String = "MIDI (*.mid)"

        Public Shared _image As String = "Supported Image Format (*.png, *.bmp, *.jpg, *.gif)"
        Public Shared _movie As String = "Supported Movie Format (*.mpg, *.avi, *.mp4, *.wmv, *.webm)"
        Public Shared BMP As String = "Windows bitmap image (*.bmp)"
        Public Shared PNG As String = "Portable Network Graphic (*.png)"
        Public Shared JPG As String = "Joint Photographic Experts Group (*.jpg)"
        Public Shared GIF As String = "Graphics Interchange Format (*.gif)"
        Public Shared MPG As String = "Moving Picture Experts Group (*.mpg)"
        Public Shared AVI As String = "Audio Video Interleave (*.avi)"
        Public Shared MP4 As String = "MPEG phase 4 (*.mp4)"
        Public Shared WMV As String = "Windows Media Video (*.wmv)"
        Public Shared WEBM As String = "WebM (*.webm)"

        Public Shared EXE As String = "Executable file (*.exe)"
    End Class

    Public Class fStatistics
        Public Shared Title As String = "Statistics"
        Public Shared lBPM As String = "BPM"
        Public Shared lSTOP As String = "STOP"
        Public Shared lSCROLL As String = "SCROLL"
        Public Shared lA As String = "A1-A8"
        Public Shared lD As String = "D1-D8"
        Public Shared lBGM As String = "BGM"
        Public Shared lTotal As String = "Total"
        Public Shared lShort As String = "Short"
        Public Shared lLong As String = "Long"
        Public Shared lLnObj As String = "LnObj"
        Public Shared lHidden As String = "Hidden"
        Public Shared lErrors As String = "Errors"
    End Class

    Public Class fopPlayer
        Public Shared Title As String = "Player Arguments Options"
        Public Shared Add As String = "Add"
        Public Shared Remove As String = "Remove"
        Public Shared Path As String = "Path"
        Public Shared PlayFromBeginning As String = "Play from beginning"
        Public Shared PlayFromHere As String = "Play from current measure"
        Public Shared StopPlaying As String = "Stop"
        Public Shared References As String = "References (case-sensitive):"
        Public Shared DirectoryOfApp As String = "Directory of the application"
        Public Shared CurrMeasure As String = "Current measure"
        Public Shared FileName As String = "File Name"
        Public Shared RestoreDefault As String = "Restore Default"
    End Class

    Public Class fopVisual
        Public Shared Title As String = "Visual Options"
        Public Shared Width As String = "Width"
        Public Shared Caption As String = "Caption"
        Public Shared Note As String = "Note"
        Public Shared Label As String = "Label"
        Public Shared LongNote As String = "Long Note"
        Public Shared LongNoteLabel As String = "Long Note Label"
        Public Shared Bg As String = "Bg"
        Public Shared ColumnCaption As String = "Column Caption"
        Public Shared ColumnCaptionFont As String = "Column Caption Font"
        Public Shared Background As String = "Background"
        Public Shared Grid As String = "Grid"
        Public Shared SubGrid As String = "Sub"
        Public Shared VerticalLine As String = "Vertical Line"
        Public Shared MeasureBarLine As String = "Measure BarLine"
        Public Shared BGMWaveform As String = "BGM Waveform"
        Public Shared NoteHeight As String = "Note Height"
        Public Shared NoteLabel As String = "Note Label"
        Public Shared MeasureLabel As String = "Measure Label"
        Public Shared LabelVerticalShift As String = "Note Label Vertical Shift"
        Public Shared LabelHorizontalShift As String = "Note Label Horizontal Shift"
        Public Shared LongNoteLabelHorizontalShift As String = "LongNote Label Horizontal Shift"
        Public Shared HiddenNoteOpacity As String = "Hidden Note Opacity"
        Public Shared NoteBorderOnMouseOver As String = "Note Border on MouseOver"
        Public Shared NoteBorderOnSelection As String = "Note Border on Selection"
        Public Shared NoteBorderOnAdjustingLength As String = "Note Border on Adjusting Length"
        Public Shared SelectionBoxBorder As String = "Selection Box Border"
        Public Shared TSCursor As String = "Time Selection Cursor"
        Public Shared TSSplitter As String = "Time Selection Splitter"
        Public Shared TSCursorSensitivity As String = "Time Selection Cursor Sensitivity"
        Public Shared TSMouseOverBorder As String = "Time Selection MouseOver Border"
        Public Shared TSFill As String = "Time Selection Fill"
        Public Shared TSBPM As String = "Time Selection BPM"
        Public Shared TSBPMFont As String = "Time Selection BPM Font"
        Public Shared MiddleSensitivity As String = "Middle Button Release Sensitivity"
    End Class

    Public Class fopGeneral
        Public Shared Title As String = "General Options"
        Public Shared MouseWheel As String = "Mouse Wheel"
        Public Shared TextEncoding As String = "Text Encoding"
        'Public Shared SortingMethod As String = "Sorting Method"
        'Public Shared sortBubble As String = "One-directional Bubble Sort"
        'Public Shared sortInsertion As String = "Insertion Sort"
        'Public Shared sortQuick As String = "Quick Sort"
        'Public Shared sortQuickD3 As String = "Quick Sort d3"
        'Public Shared sortHeap As String = "Heap Sort"
        Public Shared PageUpDown As String = "PageUp / PageDown"
        Public Shared MiddleButton As String = "Mouse Middle Button"
        Public Shared MiddleButtonAuto As String = "Click and Auto Scroll"
        Public Shared MiddleButtonDrag As String = "Click and Drag"
        Public Shared AssociateFileType As String = "Associate Filetype"
        Public Shared MaxGridPartition As String = "Max Grid Partition in BMS"
        Public Shared BeepWhileSaved As String = "Beep while saved"
        Public Shared ExtendBPM As String = "Extend number of multi-byte BPMs to 1296"
        Public Shared ExtendSTOP As String = "Extend number of STOPs to 1296"
        Public Shared AutoFocusOnMouseEnter As String = "Automatically set focus to editing panel on mouse enter"
        Public Shared DisableFirstClick As String = "Disable first click if the editing panel is not focused"
        Public Shared AutoSave As String = "AutoSave"
        Public Shared minutes As String = "minutes"
        Public Shared StopPreviewOnClick As String = "Stop preview if clicked on the editing panel"
    End Class

    Public Class fFind
        Public Shared NoteRange As String = "Note Range"
        Public Shared MeasureRange As String = "Measure Range"
        Public Shared LabelRange As String = "Label Range"
        Public Shared ValueRange As String = "Value Range"
        Public Shared to_ As String = "to"
        Public Shared Selected As String = "Selected"
        Public Shared UnSelected As String = "Unselected"
        Public Shared ShortNote As String = "Short"
        Public Shared LongNote As String = "Long"
        Public Shared Hidden As String = "Hidden"
        Public Shared Visible As String = "Visible"
        Public Shared Column As String = "Column"
        Public Shared SelectAll As String = "Select All"
        Public Shared SelectInverse As String = "Select Inverse"
        Public Shared UnselectAll As String = "Unselect All"
        Public Shared Operation As String = "Operation"
        Public Shared ReplaceWithLabel As String = "Replace with Label:"
        Public Shared ReplaceWithValue As String = "Replace with Value:"
        Public Shared Select_ As String = "Select"
        Public Shared Unselect_ As String = "Unselect"
        Public Shared Delete_ As String = "Delete"
        Public Shared Close_ As String = "Close"
    End Class

    Public Class fImportSM
        Public Shared Title As String = "Import *.SM file"
        Public Shared Difficulty As String = "Difficulty"
        Public Shared Note As String = "Please note that bg musics and STOP values will not be imported."
    End Class

    Public Class FileAssociation
        Public Shared BMS As String = "Be-Music Script"
        Public Shared BME As String = "Be-Music Extended Format"
        Public Shared BML As String = "Be-Music Longnote Format"
        Public Shared PMS As String = "Po-Mu Script"
        Public Shared IBMSC As String = "iBMSC Binary Format"
        Public Shared Open As String = "Open"
        Public Shared Preview As String = "Preview"
        Public Shared ViewCode As String = "View Code"
    End Class
End Class
