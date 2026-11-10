Functional and load testing for QuickPizza, Grafana's public demo app.

Playwright for .NET (C# + NUnit) checks that user flows work in a real browser, for one user.
k6 (JavaScript) checks how the app holds up when many virtual users hit it at once, using p95 response time and error-rate thresholds.
GitHub Actions runs both. The load job only starts if the functional tests pass.

PREREQUISITES
.NET SDK 8+	Check with dotnet --version sudo snap install dotnet-sdk --classic
PowerShell 7 (pwsh)	Playwright uses it to install browsers sudo snap install powershell
k6	sudo apt-get update && sudo apt-get install k6

SETUP
dotnet build
pwsh bin/Debug/net8.0/playwright.ps1 install

Linux: missing browser dependencies

If Playwright warns that the host is missing dependencies, install them once (use the real folder name, not netX):
sudo pwsh bin/Debug/net8.0/playwright.ps1 install-deps
pwsh bin/Debug/net8.0/playwright.ps1 install

Running the Playwright tests

From the E2ETests folder:
dotnet test
HEADED=1 dotnet test                  Linux
$env:HEADED="1"; dotnet test          Windows PowerShell

Running the k6 load test

From the repo root:
k6 run load/smoke.js

To target a different URL, set BASE_URL:
k6 run -e BASE_URL=https://your-site.example load/smoke.js

OUTPUT
The checks pass rate
http_req_duration p(95)
A ✓ or ✗ next to each threshold

The workflow in .github/workflows/tests.yml runs on every push and can also be triggered manually (workflow_dispatch).

Job	    What it does
e2e	    Builds the project, installs Playwright browsers, runs dotnet test
load	Runs load/smoke.js with k6 in Docker. Starts only if e2e passes (needs: e2e)

To see the gate in action, temporarily change the threshold to p(95)<1 in load/smoke.js, push, and watch the load job fail.