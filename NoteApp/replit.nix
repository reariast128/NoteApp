{ pkgs }: {
	deps = [
   pkgs.dotnetPackages.NewtonsoftJson
		pkgs.jq.bin
    pkgs.dotnet-sdk
    pkgs.omnisharp-roslyn
	];
}