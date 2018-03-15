$dirsource = "C:\Users\503045\Desktop\Source\"

$filecount = (dir $dirsource | measure).Count;

if ($filecount -gt 0){
    get-childitem -path $dirsource *.txt -recurse | remove-item -force -recurse
}

For($i=1; $i -lt 10; $i++){
    $newitem = $dirsource + "\test" + $i + ".txt"
    New-Item $newitem -type file
}
    