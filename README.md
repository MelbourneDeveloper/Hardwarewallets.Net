# Hardwarewallets.Net
Cross Platform C# Library for Cryptocurrency Hardwarewallets. The aim is to achieve uniform access to all the major wallets and all supported coins on all the major platforms.

Join us on Slack:
https://hardwarewallets.slack.com

Currently supports:
* .NET Framework
* .NET Core
* Android
* UWP 

## Purpose
This library is a work in progress. The concept of this library is to put a set of public interfaces over the top of basic cryptocurrency operations like getting a public key, signing a transaction, and so on. The three things that currently make this very complicated is that all these things need to be done for different cryptocurrencies, on different platforms, and with different hardware wallets. The point of this library is to put a layer over the top of all these things so that any programmer with a reasonable knowledge of cryptocurrency can start using the major hardwarewallets like Trezor, Ledger, and KeepKey from their code. The hardwarewallet market is picking up speed and there are more wallets being introduced all the time, so this library hopes to keep up as best as possible.

## NuGet

Install-Package Hardwarewallets.Net

## Progress
Current Coin Types (and their clones):

- Bitcoin
- Ethereum

Current Hardwarewallets

- Trezor
- Ledger
- KeepKey

## Contribution

I welcome feedback, and pull requests. If there's something that you need to change in the library, please log an issue, and explain the problem. If you have a proposed solution, please write it up and explain why you think it is the answer to the problem. The best way to highlight a bug is to submit a pull request with a unit test that fails so I can clearly see what the problem is in the first place.

### Pull Requests

Please break pull requests up in to their smallest possible parts. If you have a small feature of refactor that other code depends on, try submitting that first. Please try to reference an issue so that I understand the context of the pull request. If there is no issue, I don't know what the code is about. If you need help, please jump on Slack here: https://hardwarewallets.slack.com

## Donate

All Hardwarewallets.Net libraries are open source and free. Your donations will contribute to making sure that these libraries keep up with the latest hardwarewallet firmware, functions are implemented, and the quality is maintained.

Bitcoin: 33LrG1p81kdzNUHoCnsYGj6EHRprTKWu3U

Ethereum: 0x7ba0ea9975ac0efb5319886a287dcf5eecd3038e

Litecoin: MVAbLaNPq7meGXvZMU4TwypUsDEuU6stpY
