How to run this solution:
1. Via `dotnet run --project src/PrintCalculator.API/PrintCalculator.API.csproj` in root folder for local testing purposes
2. Via helm:
    * Navigate to the root folder (src, chart has to be visible)
    * `docker build -f src/PrintCalculator.API/Dockerfile -t hhglobal-printcalculatork8s:v1 .` to build the image
    * `helm install hhglobal-print-calculator ./chart/`
    * `kubectl get all --selector app=PrintCalculator` to verify that the pod is running
    * `kubectl port-forward service/hhglobal-print-calculator-service 5265:8888` to redirect HTTP traffic to our pod
    * Run postman tests
    * `helm uninstall hhglobal-print-calculator` once you are done