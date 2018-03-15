#Check if Directory Exists

$dirsource = "C:\Users\503045\Desktop\Source"
$dirdestination = "C:\Users\503045\Desktop\Destination"

if ( Test-Path $dirsource ) {
    echo "Source Directory Exists"

    #Check how many files are in directory
    $sourcefilecount = (dir $dirsource | measure).Count;
    echo "Source File Count: " $sourcefilecount 

} else {
    
    echo "Source Directory Doesn't Exist"
    EXIT 

}


#Check if source directory exist

if ( Test-Path $dirdestination ) {

    echo "Destination Directory Exists"

    #Check how many files in directory
    $destinationfilecount = (dir $dirdestination | measure).Count;
    echo "Destination File Count: " $destinationfilecount 

    #If one or more files exists delete them
    if ($sourcefilecount -gt 0 -and $destinationfilecount -gt 0){

        get-childitem -path $dirdestination *.txt -recurse | remove-item -force -recurse
    }

} else {
    
     echo "Destination Directory Doesn't Exist"
     EXIT 
}


if ($sourcefilecount -gt 0 -and $destinationfilecount -eq 0){

    	
    get-childitem -path $dirsource *.txt -recurse | move-item -destination $dirdestination

    echo "Move completed"

}


#Write-Host "Testing"