# Hardwarewallets.Net
Cross platform, C# Hardwarewallet library with uniform access to all the major hardwarewallets and all supported coins on all the major platforms.

## Purpose
This library is a work in progress. The concept of this library is to put a public interface over the top of basic cryptocurrency operations like getting a public key, signing a transaction, and so on. The three things that currently make this very complicated is that all these things need to be done for different cryptocurrencies, on different platforms, and with different hardware wallets. The point of this library is to put a layer over the top of all these things so that any programmer with a reasonable knowledge of cryptocurrency can start using the major hardwarewallets like Trezor, Ledger, and KeepKey from their code. The hardwarewallet marking is picking up speed and there are more wallets being introduced all the time, so this library hopes to keep up as best as possible.

## Progress
Current Coin Types (and their clones):

- Bitcoin
- Ethereum

Current Platforms:

- Android
- UWP
- Net Core / Framework (Windows)

Current Hardwarewallets

- Trezor
- Ledger

