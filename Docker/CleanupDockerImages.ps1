param(
    [string]$Repo
)

docker ps -a -q | %{docker rm -f $_}

docker images |
    where {(!$Repo) -or ($_.StartsWith("$Repo "))} |
    %{$_.Split(' ', [System.StringSplitOptions]::RemoveEmptyEntries)[2]} |
    select-object -unique |
    %{docker rmi -f $_}