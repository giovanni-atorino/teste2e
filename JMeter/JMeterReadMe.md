# JMeter guide
Quick wiki for JMeter script execution through pipeline and reporting best practices.

## Execution
Script can be executed through pipeline with the following command:
```
jmeter -n -t script_name.jmx -Jparameter=xxx -l results01.csv -q "user.properties file location on agent" -e -o HTML-Report
```

In case a KeyStore is used:
```
jmeter -Djavax.net.ssl.keyStoreType=<keyStoreType e.g pkcs12> -Djavax.net.ssl.keyStore=<keyStoreName> -Djavax.net.ssl.keyStorePassword=<keyStorePassword> -n -t script_name.jmx -Jparameter=xxx -l results01.csv -q "user.properties file location on agent" -e -o HTML-Report
```
N.B. keyStorePassword shall be parametrized in pipeline variables and hidden.

Useful link to set KeyStore in JMeter:
[JMeter KeyStore](https://www.blazemeter.com/blog/how-set-your-jmeter-load-test-use-client-side-certificates)

Useful link to configure user.properties file:
[JMeter Reporting Dashboard](https://jmeter.apache.org/usermanual/generating-dashboard.html)

## Parametrization
Jmeter scripts shall be parametrized in order to be configured through Azure pipelines right before the execution.
The following fields shall be parametrized (maintain the following naming convention, case sensitive):
- threads
- RPS
- duration
- minDate (when available)
- maxDate (when available)
- Host (when possible)
- subscription_key (when possible)

A parameter in JMeter script is defined as: ```${__P(parameterName)}```. This parameter in command line script is recalled with:  ```-JparameterName=parameterValue```. 
This value can be inserted as a pipeline variable settable at queque time, and recalled in the command line as follow: ```-JparameterName=$(pipelineParameterValue)```

## Test reports
Performance test deliverable folder shall contain all HTML-Report downloaded from artifacts, unzipped and renamed with the following format: 
```
yyyyMMdd_CloudProvider_ApplicationUnderTest_Environment_APIsList_Duration[ms]_RPS_threads
```
e.g.
```
20220615_AWS_EDS_PROD_WEBAPI_3600_5_35
20220610_AZURE_EDS_DEV_EDSIvecoON_1800_5_35
```
N.B: yyyyMMdd represents the execution date

## Summary report
For a quick results analysis and confrontation, a single excel shall be created, with a detail of each execution in separate sheets. Execution details are:
- Title of the execution (e.g. "AWS PROD execution of EDS WEBAPI - 1h 5req/s")
- Name of the artifact: yyyyMMdd_CloudProvider_ApplicationUnderTest_Environment_APIsList_Duration[ms]_RPS_threads
- Table with summary of execution (response time, error rate, number of requests, etc.)
- Graph: response time vs. duration