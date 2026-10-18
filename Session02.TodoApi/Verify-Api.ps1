param([string]$BaseUrl = 'http://localhost:5082')
$ErrorActionPreference = 'Stop'

function Check-Response($Method, $Path, $Expected, $Body = $null) {
    $parameters = @{ Uri = "$BaseUrl$Path"; Method = $Method; SkipHttpErrorCheck = $true }
    if ($null -ne $Body) {
        $parameters.ContentType = 'application/json'
        $parameters.Body = $Body | ConvertTo-Json
    }
    $response = Invoke-WebRequest @parameters
    if ([int]$response.StatusCode -ne $Expected) {
        throw "$Method $Path expected $Expected, received $($response.StatusCode): $($response.Content)"
    }
    Write-Host "PASS $Method $Path -> $Expected"
    return $response
}

$null = Check-Response GET '/todos' 200
$created = Check-Response POST '/todos' 201 @{ title = '  Verify CRUD  ' }
$task = $created.Content | ConvertFrom-Json
if ($task.title -ne 'Verify CRUD' -or $task.isCompleted -ne $false) { throw 'Incorrect created task.' }
if (-not ([string]$created.Headers.Location).EndsWith("/todos/$($task.id)")) { throw 'Incorrect Location header.' }
$path = "/todos/$($task.id)"
$null = Check-Response GET $path 200
$null = Check-Response PUT $path 204 @{ title = 'Updated task'; isCompleted = $true }
$updated = (Check-Response GET $path 200).Content | ConvertFrom-Json
if ($updated.title -ne 'Updated task' -or $updated.isCompleted -ne $true) { throw 'Update was not stored.' }
$null = Check-Response POST '/todos' 400 @{ title = '   ' }
$null = Check-Response PUT $path 400 @{ title = '   '; isCompleted = $false }
$unchanged = (Check-Response GET $path 200).Content | ConvertFrom-Json
if ($unchanged.title -ne 'Updated task' -or $unchanged.isCompleted -ne $true) { throw 'Invalid update changed the task.' }
$null = Check-Response GET '/todos/2147483647' 404
$null = Check-Response PUT '/todos/2147483647' 404 @{ title = 'Missing'; isCompleted = $true }
$null = Check-Response DELETE '/todos/2147483647' 404
$null = Check-Response DELETE $path 204
$null = Check-Response GET $path 404
$null = Check-Response DELETE $path 404
$null = Check-Response GET '/todos/abc' 404
Write-Host 'All HTTP checks passed.'
