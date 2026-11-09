{
  description = "shopping cart tdd";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/26.05";
  };

  outputs = {nixpkgs, ...}: let
    inherit (nixpkgs) lib;
    supportedSystems = ["x86_64-linux" "aarch64-linux" "x86_64-darwin" "aarch64-darwin"];
    forAllSystems = f: lib.genAttrs supportedSystems (system: f system);
  in {
    devShells = forAllSystems (system: let
      pkgs = nixpkgs.legacyPackages.${system};
    in {
      default = pkgs.mkShell {
        packages = with pkgs; [
          dotnet-sdk_10
          csharp-ls
          figlet
        ];

        shellHook = ''
          figlet "shopping cart"
        '';
      };
    });
  };
}
