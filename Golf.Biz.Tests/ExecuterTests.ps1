# Script pour l'exécution des tests.

# Variables de travail.
$cheminDesktop = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::Desktop)
$cheminRepertoire = $cheminDesktop + "\Examen\Question3\ResultatsTests\"

# Exécution des tests
dotnet test -r $cheminRepertoire -l trx --filter "TestCategory=Service de calcul du score final"